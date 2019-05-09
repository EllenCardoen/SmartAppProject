﻿using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Models;
using Project.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public class SearchRepository : ISearchRepository
    {

        public async Task<List<Track>> GetAllTracks(string clientId)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/tracks/?client_id={clientId}&limit=20".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<Track>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Track>> SearchTrack(string clientId, string searchRequest)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/tracks/?client_id={clientId}&format=jsonpretty&limit=20&search={searchRequest}".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<Track>>();
            }
            catch(FlurlHttpException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Track> SearchTrackById(string clientId, DatabaseIdContent id)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/tracks/?client_id={clientId}&format=jsonpretty&id={id.id}".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").First.ToObject<Track>();
            }
            catch(FlurlHttpException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Track>> GetAllPlaylistTracks(string clientId, string userName,string PlaylistName)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/playlists/tracks/?client_id={clientId}&format=jsonpretty&limit=10&user_name={userName}&name={PlaylistName}&track_type=albumtrack".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<Track>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<News>> GetNews(string clientId)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/feeds/?client_id={clientId}&format=jsonpretty&limit=10&type=news".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<News>>();
            }
            catch(FlurlHttpException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AlbumNews>> GetAlbum(string clientId)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/feeds/?client_id={clientId}&format=jsonpretty&limit=10&type=album".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<AlbumNews>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Album>> SearchAlbum(string clientId, string searchRequest)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/albums/?client_id={clientId}&format=jsonpretty&limit=20&namesearch={searchRequest}".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<Album>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ArtistNews>> GetArtist(string clientId)
        {
            try
            {
                var getResponse = await $"https://api.jamendo.com/v3.0/feeds/?client_id={clientId}&format=jsonpretty&limit=30&type=artist".GetJsonAsync<JObject>();
                return getResponse.SelectToken("results").ToObject<List<ArtistNews>>();
            }
            catch (FlurlHttpException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
