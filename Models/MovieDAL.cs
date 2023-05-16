using RestSharp;

namespace OMDB_API.Models
{
    public class MovieDAL
    {
        public Movie GetMovie(string title)
        {
            RestClient client = new RestClient($"http://www.omdbapi.com/?t={title}&apikey=e3ee70be");
            RestRequest request = new RestRequest();
            Task<Movie> response = client.GetAsync<Movie>(request);
            Movie m = response.Result;
            return m;

        }
    }
}
