using System.ComponentModel.DataAnnotations;

namespace Demo3.Dto.Players
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }

    }
}
