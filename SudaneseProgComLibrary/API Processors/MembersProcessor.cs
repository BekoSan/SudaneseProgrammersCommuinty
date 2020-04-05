using SudaneseProgComLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace SudaneseProgComLibrary.APIProcessors
{
    public class MembersProcessor
    {
        public static async Task<IEnumerable<Member>> LoadAllMembers()
        {
            //new ApiHelper();
            //ApiHelper.ApiClient = new HttpClient();

            string url = ApiHelper.apiUrl + "/members";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IEnumerable<Member>>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<Member> LoadMemberProfile(int Id)
        {
            string url = ApiHelper.apiUrl + $"/members/{Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Member>();

                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> CreateMember(Member member)
        {
            string url = ApiHelper.apiUrl + $"/members/New";
            bool output = false;

            var data = new ObjectContent(member.GetType(), member, new JsonMediaTypeFormatter());

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;
                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> UpdateMember(int Id, Member member)
        {
            string url = ApiHelper.apiUrl + $"/members/Update/{Id}";
            bool output = false;

            var data = new ObjectContent(member.GetType(), member, new JsonMediaTypeFormatter());

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, data))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;

                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<bool> DeleteMember(int Id)
        {
            string url = ApiHelper.apiUrl + $"/members/Delete/{Id}";
            bool output = false;
            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    output = true;

                    return output;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}