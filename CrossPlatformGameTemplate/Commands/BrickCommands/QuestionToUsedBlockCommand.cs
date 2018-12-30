using SuperMario.Entities.Blocks;
using System.Collections.Generic;

namespace SuperMario.Commands.BrickCommands
{
    class QuestionToUsedBlockCommand : ICommand
    {
        private List<QuestionBlock> questionBlocks;
        public QuestionToUsedBlockCommand(List<QuestionBlock> questionBlocks)
        {
            this.questionBlocks = questionBlocks;
        }
        public void Execute()
        {
            foreach (QuestionBlock brickBlock in questionBlocks)
            {
                brickBlock.Hit(PowerUpType.RedMushroom);
            }
        }
    }
}
