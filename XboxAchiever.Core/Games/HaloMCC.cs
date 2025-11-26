
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XboxAchiever.Core.Games
{
    internal class HaloMCC : XboxGame
    {
        public HaloMCC(CancellationToken cancellationToken) : base(cancellationToken) { }

        public override void Start()
        {
            // Use Win Boost map. Focus on Start menu option

            while (!cancellationToken.IsCancellationRequested)
            {
                // Starts the game
                xboxController.PressButton(XboxController.Button.A);

                // Wait for game to be over and back to game report
                Thread.Sleep(30000);

                // Exist game report
                xboxController.PressButton(XboxController.Button.B);

                // Let time for game menu to be ready
                Thread.Sleep(3000);

                // Move to the Start menu option
                MoveInMenu(Direction.Right);
                MoveInMenu(Direction.Right);
                MoveInMenu(Direction.Right);
            }  
        }

        private void MoveInMenu(Direction direction)
        {
            xboxController.Move(direction, 100);
            Thread.Sleep(500); // Menu is slow
        }
    }
}
