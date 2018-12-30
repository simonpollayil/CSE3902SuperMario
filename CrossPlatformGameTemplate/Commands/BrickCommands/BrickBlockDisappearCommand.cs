using SuperMario.Entities.Blocks;
using System.Collections.Generic;


namespace SuperMario.Commands.BrickCommands
{
    class BrickBlockDisappearCommand : ICommand
    {
        private List<BrickBlock> brickBlocks;
        public BrickBlockDisappearCommand(List<BrickBlock> brickBlocks)
        {
            this.brickBlocks = brickBlocks;
        }
        public void Execute()
        {
            foreach (BrickBlock brickBlock in brickBlocks)
            {
                brickBlock.Hit();
            }
        }
    }
}
