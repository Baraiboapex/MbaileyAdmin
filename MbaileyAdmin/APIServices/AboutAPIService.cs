using MbaileyAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MbaileyAdmin.DummyAPI
{
    internal class AboutAPIService
    {
        private readonly List<About> _aboutPagePosts = new List<About>() {
          new About()
          {
              Id = 1,
              Message = "This is an about page message!",
              OwnerImage="",
              DatePosted= DateTime.Now,
          }
        };
        private readonly ServiceResponse _serviceResponse = new ServiceResponse();
        public AboutAPIService() { }

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

        public ServiceResponse GetLatestAboutPagePost(int numberOfMostRecentItems)
        {
            try
            {
                var aboutPost = _aboutPagePosts.Max(x => x.DatePosted);

                if (aboutPost != null)
                {
                    var postData = new Dictionary<string, object>();

                    postData.Add("aboutPost", aboutPost);

                    return BuildResponse(true, $"Post Found", postData);
                }
                else
                {
                    throw new Exception("Could Not Find Any About Page Posts");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BuildResponse(false, ex.Message);
            }
        }

        public ServiceResponse EditAboutPage(BlogPost postToEdit)
        {
            try
            {
                var currentPost = _aboutPagePosts.FirstOrDefault(p => p.Id == postToEdit.Id);

                if (currentPost != null)
                {
                    currentPost.Title = postToEdit.Title;
                    currentPost.Message = postToEdit.Content;

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

    }
}
