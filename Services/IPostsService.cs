using BackendHectorDeLeon.DTOs;

namespace BackendHectorDeLeon.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
}
