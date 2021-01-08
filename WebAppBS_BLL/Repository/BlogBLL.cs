using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppBS.Model;
using WebAppBS.Model.VM;
using WebAppBS_BLL.IRepository;
using WebAppDBContext;

namespace WebAppBS_BLL.Repository
{
   public class BlogBLL : IBlog
    {


        private readonly AspContext _aspContext;
        public BlogBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            try
            {
                var res = await _aspContext.Blog.AddAsync(blog);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<object> GetUserBlogDetails(BlogFilterPagination blogFilter)
        {
            PaginationResponse paginationResponse = new PaginationResponse();

            try
            {
                List<BlogDataVM> lstVMGroupData = new List<BlogDataVM>();
                BlogDataVM vMGroupData = new BlogDataVM();

                if (string.IsNullOrEmpty(blogFilter.blogFilter.User))
                {

                    var res = await _aspContext.Blog.Select(b => new Blog()
                    {

                        Comments = b.Comments,
                        NumberOfComments = b.Comments.Count,
                        CreatedBy = b.CreatedBy,
                        CreatedTime = DateTime.UtcNow,
                        BlogContent = b.BlogContent,
                        BlogID = b.BlogID,

                    }).ToListAsync();

                    foreach (var item in res)
                    {
                        foreach (Comments items in item.Comments)
                        {
                            var vote = await _aspContext.LikeOrDisLikes.Where(p => p.CommentsID == items.CommentsID).ToListAsync();
                            if (vote != null)
                            {
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == true);
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == false);
                            }

                        }

                    }
                    blogFilter.Pagination.totalItems = res.Count;
                    paginationResponse.Data = res.Skip((blogFilter.Pagination.currentPage - 1) * blogFilter.Pagination.itemsPerPage)
                                .Take(blogFilter.Pagination.itemsPerPage).GroupBy(p => p.BlogID).ToList();
                    paginationResponse.Pagination = blogFilter.Pagination;



                }
                else
                {
                    var res = await _aspContext.Blog.Where(b => b.BlogContent.Equals(blogFilter.blogFilter.User)).Select(b => new Blog()
                    {

                        Comments = b.Comments,
                        NumberOfComments = b.Comments.Count,
                        CreatedBy = b.CreatedBy,
                        CreatedTime = DateTime.UtcNow,
                        BlogContent = b.BlogContent,
                        BlogID = b.BlogID,

                    }).ToListAsync();

                    foreach (var item in res)
                    {
                        foreach (Comments items in item.Comments)
                        {

                            var vote = _aspContext.LikeOrDisLikes.Where(p => p.CommentsID == items.CommentsID).ToList();
                            if (vote != null)
                            {


                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == true);
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == false);
                            }

                        }

                    }
                    blogFilter.Pagination.totalItems = res.Count;
                    paginationResponse.Data = res.Skip((blogFilter.Pagination.currentPage - 1) * blogFilter.Pagination.itemsPerPage)
                                .Take(blogFilter.Pagination.itemsPerPage).GroupBy(p => p.BlogID).ToList();
                    paginationResponse.Pagination = blogFilter.Pagination;



                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return paginationResponse;
        }
    }
}
