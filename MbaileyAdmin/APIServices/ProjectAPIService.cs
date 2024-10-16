using MbaileyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbaileyAdmin.DummyAPI
{
    public class ProjectAPIService
    {
        private readonly List<Project> _projects = new List<Project>() {
          new Project(){
                Id = 1,
                Title = "Test",
                ProjectCategories = new List<Category>()
                {
                    new Category
                    {
                        Id = 1,
                        Title= "Category Test",
                    }
                },
                ProjectComments = new List<Comment>()
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

            if (data != null)
            {
                _serviceResponse.Data = data;
            }

            return _serviceResponse;
        }

        public ProjectAPIService() { }

        public ServiceResponse GetSingleProject(int postId)
        {
            try
            {
                var projects = _projects.SingleOrDefault(p => p.Id == postId);

                if (projects != null)
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("Project", projects);

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

        public ServiceResponse GetAllProjects()
        {
            try
            {
                var projects = _projects;

                if (projects.Any())
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("Projects", projects);

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

        public ServiceResponse GetLatestProjects(int numberOfMostRecentItems)
        {
            try
            {
                var projects = _projects.Distinct()
                    .OrderByDescending(p => p.DateAdded)
                    .Take(numberOfMostRecentItems)
                    .ToList();

                if (projects.Any())
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("Projects", projects);

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

        public ServiceResponse AddProject(Project newPost)
        {
            try
            {
                if (newPost != null)
                {
                    _projects.Add(newPost);

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

        public ServiceResponse EditProject(Project postToEdit)
        {
            try
            {
                var currentPost = _projects.FirstOrDefault(p => p.Id == postToEdit.Id);

                if (currentPost != null)
                {
                    currentPost.Title = postToEdit.Title;
                    currentPost.AboutProject = postToEdit.AboutProject;
                    currentPost.ProjectImage = postToEdit.ProjectImage;

                    return BuildResponse(true, "Post Edited Successfully!");
                }
                else
                {
                    throw new Exception("Post not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NOPE! : " + ex.Message);

                return BuildResponse(false, ex.Message); ;
            }
        }

        public ServiceResponse DeleteProject(Project postToDelete)
        {
            try
            {
                var currentPost = _projects.FirstOrDefault(p => p.Id == postToDelete.Id);

                if (currentPost != null)
                {
                    currentPost.IsDeleted = true;

                    return BuildResponse(true, "Post Deleted!");
                }
                else
                {
                    throw new Exception("Post not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("NOPE! : " + ex.Message);

                return BuildResponse(true, ex.Message); ;
            }

        }
    }
}
