using MbaileyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MbaileyAdmin.DummyAPI
{
    public class BlogPostAPIService
    {
        private readonly List<BlogPost> _blogPosts = new List<BlogPost>() {
          new BlogPost(){
                Id = 1,
                Title = "Test",
                BlogCategories = new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Title= "Category Test",
                    }
                },
                BlogComments = new List<Comment>()
                {
                    new Comment(){
                        Id = 1,
                        Commenter="matthewpbaileydesigns@gmail.com",
                        Content="Bla bla bla!",
                        DatePosted= DateTime.Now,
                    },
                    new Comment(){
                        Id = 2,
                        Commenter="matthewpbaileydesigns@gmail.com",
                        Content="Bla bla bla 2!",
                        DatePosted= DateTime.Now,
                    }
                }
            }
        };
        private readonly ServiceResponse _serviceResponse = new ServiceResponse();

        private ServiceResponse BuildResponse(bool success, string message, Dictionary<string, object> data = null) 
        {
            _serviceResponse.Success = success;
            _serviceResponse.Message = message;

            if (data != null) {
                _serviceResponse.Data = data;
            }

            return _serviceResponse;
        }

        public BlogPostAPIService() { }

        public ServiceResponse GetSingleBlogPost(int postId) 
        {
            try
            {
                var blogPost = _blogPosts.SingleOrDefault(p => p.Id == postId);

                if (blogPost != null)
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("blogPost", blogPost);

                    return BuildResponse(true, $"Posts Found", postData);
                }
                else
                {
                    throw new Exception("Could Not Find Selected Blog Post");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BuildResponse(false, ex.Message);
            }
        }

        public ServiceResponse GetAllBlogPosts() 
        {
            try
            {
                var blogPosts = _blogPosts;

                if (blogPosts.Any())
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("blogPosts", blogPosts);

                    return BuildResponse(true, $"Posts Found", postData);
                }
                else
                {
                    throw new Exception("Could Not Find Any Blog Posts");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BuildResponse(false, ex.Message);
            }
            
        }

        public ServiceResponse GetLatestBlogPosts(int numberOfMostRecentItems) 
        {
            try
            {
                var blogPosts = _blogPosts.Distinct()
                    .OrderByDescending(p => p.DateAdded)
                    .Take(numberOfMostRecentItems)
                    .ToList();

                if (blogPosts.Any())
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("blogPosts", blogPosts);

                    return BuildResponse(true, $"Posts Found", postData);
                }
                else
                {
                    throw new Exception("Could Not Find Any Blog Posts");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BuildResponse(false, ex.Message);
            }
        }

        public ServiceResponse AddBlogPost(BlogPost newPost) 
        {
            try
            {
                if (newPost != null) 
                {
                    _blogPosts.Add(newPost);

                    return BuildResponse(true, $"New Post {newPost.Title} Added!");
                }
                else
                {
                    throw new Exception("Could Not Add Post!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NOPE! : " + ex.Message);

                return BuildResponse(false, ex.Message); ;
            }
            
        }

        public ServiceResponse EditBlogPost(BlogPost postToEdit) 
        {
            try {
                var currentPost = _blogPosts.FirstOrDefault(p => p.Id == postToEdit.Id);

                if (currentPost != null)
                {
                    currentPost.Title = postToEdit.Title;
                    currentPost.Content = postToEdit.Content;

                    return BuildResponse(true, "Post Edited Successfully!");
                }
                else {
                    throw new Exception("Post not found!");
                }
            }
            catch (Exception ex) {
                Console.WriteLine("NOPE! : "+ex.Message);

                return BuildResponse(false, ex.Message); ;
            }
        }

        public ServiceResponse DeleteBlogPost(BlogPost postToDelete)
        {
            try
            {
                var currentPost = _blogPosts.FirstOrDefault(p => p.Id == postToDelete.Id);

                if (currentPost != null)
                {
                    currentPost.IsDeleted = true;

                    return BuildResponse(true, "Post Deleted!");
                }
                else {
                    throw new Exception("Post not found!");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("NOPE! : " + ex.Message);

                return BuildResponse(true, ex.Message); ;
            }
            
        }
    }
}
