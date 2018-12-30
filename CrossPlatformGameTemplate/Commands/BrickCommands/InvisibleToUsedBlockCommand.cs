using SuperMario.Entities.Blocks;
using System.Collections.Generic;

namespace SuperMario.Commands.BrickCommands
{
    class InvisibleToUsedBlockCommand : ICommand
    {
        private List<InvisibleBlock> invisibleBlocks;
        public InvisibleToUsedBlockCommand(List<InvisibleBlock> invisibleBlocks)
        {
            this.invisibleBlocks = invisibleBlocks;
        }
        public void Execute()
        {
            foreach (InvisibleBlock invisibleBlock in invisibleBlocks)
            {
                invisibleBlock.Hit(PowerUpType.RedMushroom);
            }
        }
    }
}
