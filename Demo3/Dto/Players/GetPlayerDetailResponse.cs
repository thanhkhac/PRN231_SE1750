using Demo3.Dto.PlayerInstrument;

namespace Demo3.Dto.Players
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments {  get; set; }
    }
}
