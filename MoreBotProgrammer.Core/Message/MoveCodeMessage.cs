namespace MoreBotProgrammer.Core
{
    class MoveCodeMessage : CodeMessage
    {
        public MoveCodeMessage(MoveBlock moveBlock)
        {
            command = "move";
            data = (int)moveBlock.Direction + moveBlock.Speed.ToString();
        }
    }
}
