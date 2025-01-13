using Demo3.Dto.PlayerInstrument;

namespace Demo3.Dto.Players
{
    public class CreatePlayerRequest
    {
        public string NickName { get; set; }
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; }
    }
}
