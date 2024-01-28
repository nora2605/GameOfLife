# GameOfLife

C# implementation of Conway's Game of Life using Windows Forms and GDI.

Supports up to 1 million cells (arbitrary limit), with a maximum of 1000 cells in any direction.

## Installation

Install the .NET 8.0 Desktop Runtime and download the latest release from the releases page.

If you're on an unsupported platform, you can build it yourself (see below).

## Usage

Use the mouse to draw cells on the grid (due to the nature of the event system, sometimes a line of cells will be drawn if the grid is big and that might result in some less curvy lines), if you click on an alive cell and draw you will instead erase any in your path.

Click the Step button to advance the simulation by one step, or the Play button to start the simulation.

Drawing will pause the simulation while your mouse is down, and will resume when you release it.

Use the UpDown controls to change the grid size; the slider at the top is for the step tick rate (won't go faster than your cpu/the .net parallelism implementation can keep up with)

and that's it!

## Building

Just use Visual Studio 2022 with .NET 8 installed.

## License

MIT License yay

## Contributing

This is literally just a tiny demo and there are already way better implementations of this out there, so I don't expect anyone to contribute to this, but if you want to, feel free to open a PR or an issue.
