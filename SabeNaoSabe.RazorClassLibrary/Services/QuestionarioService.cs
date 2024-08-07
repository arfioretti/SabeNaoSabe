﻿using SabeNaoSabe.RazorClassLibrary.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Unicode;
using System.Text;
using System.Net.Http.Json;
using System.Net.Http;
using System.Collections.Generic;

namespace SabeNaoSabe.RazorClassLibrary.Services
{
    public class QuestionarioService : IQuestionarioService
    {
        public string _baseUrl = string.Empty;

        public async Task<List<QuestionarioModel>> GetQuestionarios(string baseUrl)
        {
            _baseUrl = baseUrl;
            var questionarios = new List<QuestionarioModel>();
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/api/questionario";
                var apiresponse = await client.GetAsync(url);
                if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK) 
                {
                    var response = await apiresponse.Content.ReadAsStringAsync();
                    questionarios = JsonConvert.DeserializeObject<List<QuestionarioModel>>(response.ToString());
                }
            }
            return questionarios;
        }
        public async Task<QuestionarioModel> GetQuestionarioById(int id)
        {
            QuestionarioModel questionario = new QuestionarioModel();
            using (var client = new HttpClient())
            {
                string url = $"{_baseUrl}/api/questionario/" + id.ToString();
                var apiresponse = await client.GetAsync(url);
                if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var response = await apiresponse.Content.ReadAsStringAsync();
                    questionario = JsonConvert.DeserializeObject<QuestionarioModel>(response.ToString());
                }
            }
            return questionario;
        }
        public async Task<bool> EditQuestionario(QuestionarioModel questionarioModel)
        {
            var ret = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Questionario";
                    var serializeContent = JsonConvert.SerializeObject(questionarioModel);

                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Put;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(serializeContent, encoding: Encoding.UTF8, "application/json");
                    var apiresponse = await client.PutAsync(url, new StringContent(serializeContent, encoding: Encoding.UTF8, "application/json"));
                   
                    //var apiresponse = await client.SendAsync(request);
                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    { 
                        ret = true;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return ret;
        }
        public async Task<bool> DeleteQuestionario(QuestionarioModel questionarioModel)
        {
            var ret = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Questionario";
                    var serializeContent = JsonConvert.SerializeObject(questionarioModel);

                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(serializeContent, encoding: Encoding.UTF8, "application/json"); 

                    var apiresponse = await client.SendAsync(request); 
                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiresponse.Content.ReadAsStringAsync();
                        var deserilizeResponse = JsonConvert.DeserializeObject<QuestionarioModel>(response.ToString());
                        if (deserilizeResponse.Id > 0)
                        {
                            ret = true;
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return ret;
        }

        public async Task<bool> AddQuestionario(QuestionarioModel questionarioModel)
        {
            var ret = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Questionario";
                    var serializeContent = JsonConvert.SerializeObject(questionarioModel);

                    var apiresponse = await client.PostAsync(url, new StringContent(serializeContent, encoding: Encoding.UTF8, "application/json"));
                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiresponse.Content.ReadAsStringAsync();
                        var deserilizeResponse = JsonConvert.DeserializeObject<QuestionarioModel>(response.ToString());
                        if (deserilizeResponse.Id > 0)
                        {
                            ret = true;
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return ret;
        }

        public async Task<bool> AddUploadedFile(UploadedFile uploadedFile)
        {
            var ret = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Questionario/UploadedFile";
                    var serializeContent = JsonConvert.SerializeObject(uploadedFile);

                    var apiresponse = await client.PostAsync(url, new StringContent(serializeContent, encoding: Encoding.UTF8, "application/json"));
                }
                return ret;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return ret;
        }

        public async Task<UploadedFile> GetUploadedFile(string name)
        {
            UploadedFile uploadedFile = new UploadedFile();    
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseUrl}/api/Questionario/GetUploadedFile?name={name}";
                    var apiresponse = await client.GetAsync(url);

                    if (apiresponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiresponse.Content.ReadAsByteArrayAsync();
                        //uploadedFile = JsonConvert.DeserializeObject<UploadedFile>(response.ToString());
                        uploadedFile.FileContent = response;
                        uploadedFile.FileName = name;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return uploadedFile;
        }
    }
}
