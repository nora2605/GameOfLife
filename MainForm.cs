using System.Windows;

namespace GameOfLife;

public partial class MainForm : Form
{
    private int hSize, vSize;

    private readonly System.Windows.Forms.Timer stepTimer;
    private readonly System.Windows.Forms.Timer renderTimer;
    private bool[,] cells;
    private bool[,] cellBuffer;

    private Bitmap imageBuffer;

    private float sqWidth;
    private float xOff;
    private float yOff;

    private bool drawing;
    private bool erasing;

    private bool playing;

    public MainForm()
    {
        InitializeComponent();

        hSize = (int)xDim.Value;
        vSize = (int)yDim.Value;

        cells = new bool[hSize, vSize];
        cellBuffer = new bool[hSize, vSize];

        stepTimer = new()
        {
            Interval = 1000
        };
        renderTimer = new()
        {
            Interval = 20
        };
        renderTimer.Tick += R_Tick;
        stepTimer.Tick += Step_Tick;
        for (int i = 0; i < cells.GetLength(0); i++)
            for (int j = 0; j < cells.GetLength(1); j++)
                cells[i, j] = false;
        canvas.MouseDown += Canvas_MouseDown;
        canvas.MouseUp += Canvas_MouseUp;
        canvas.MouseMove += Canvas_MouseMove;

        imageBuffer = new Bitmap(canvas.Width, canvas.Height);
        CalculateMetric();
        Load += (_, _) => Render();
        renderTimer.Enabled = true;
        Click += (_, _) => buttonStep.Focus();
    }

    private void CalculateMetric()
    {
        sqWidth = Math.Min((float)canvas.Height / vSize, (float)canvas.Width / hSize);
        xOff = Math.Max((canvas.Width - sqWidth * hSize) / 2, 0);
        yOff = Math.Max((canvas.Height - sqWidth * vSize) / 2, 0);
    }

    private void Step_Tick(object? sender, EventArgs e)
    {
        if (playing)
        {
            Step();
        }
    }
    private void R_Tick(object? sender, EventArgs e)
    {
        Render();
    }

    private void Canvas_MouseUp(object? sender, MouseEventArgs e)
    {
        erasing = false;
        drawing = false;
        playing = true;
        prevX = -1;
        prevY = -1;
    }

    private void Canvas_MouseDown(object? sender, MouseEventArgs e)
    {
        buttonStep.Focus();
        if (e.Button == MouseButtons.Left)
        {
            playing = false;
            int x = (int)Math.Floor((e.X - xOff) / sqWidth);
            int y = (int)Math.Floor((e.Y - yOff) / sqWidth);
            if (x >= 0 && x < hSize && y >= 0 && y < vSize)
            {
                drawing = !cells[x, y];
                erasing = cells[x, y];
                cells[x, y] = drawing;
                prevX = x;
                prevY = y;
            }
        }
    }

    int prevX = -1, prevY = -1;
    private void Canvas_MouseMove(object? sender, MouseEventArgs e)
    {
        int x = (int)Math.Floor((e.X - xOff) / sqWidth);
        int y = (int)Math.Floor((e.Y - yOff) / sqWidth);
        if (drawing || erasing)
        {
            if (x >= 0 && x < hSize && y >= 0 && y < vSize)
            {
                if (prevX != -1 && prevY != -1)
                {
                    int dx = x - prevX;
                    int dy = y - prevY;
                    int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                    for (int i = 0; i < steps; i++)
                    {
                        cells[prevX + (int)Math.Round((float)i * dx / steps), prevY + (int)Math.Round((float)i * dy / steps)] = drawing;
                    }
                }
                cells[x, y] = drawing;
                prevX = x;
                prevY = y;
            }
        }
    }

    private void SpeedChanged(object sender, EventArgs e)
    {
        stepTimer.Interval = 1000 / speedSlider.Value;
    }

    private void OnPlay(object sender, EventArgs e)
    {
        stepTimer.Enabled = !stepTimer.Enabled;
        if (stepTimer.Enabled)
            ((Button)sender).Text = "Pause";
        else
            ((Button)sender).Text = "Play";
    }

    private void OnStep(object sender, EventArgs e)
    {
        if (!stepTimer.Enabled)
        {
            Step();
        }
    }

    private void MainForm_SizeChanged(object sender, EventArgs e)
    {

        imageBuffer = new Bitmap(canvas.Width, canvas.Height);
        CalculateMetric();
    }

    private void StepCorners()
    {
        cellBuffer[0, 0] =
            cells[0, 0] ?
                CountNeighborsBranch(0, 0) == 2 || CountNeighborsBranch(0, 0) == 3 :
                CountNeighborsBranch(0, 0) == 3;
        cellBuffer[hSize - 1, 0] =
            cells[hSize - 1, 0] ?
                CountNeighborsBranch(hSize - 1, 0) == 2 || CountNeighborsBranch(hSize - 1, 0) == 3 :
                CountNeighborsBranch(hSize - 1, 0) == 3;
        cellBuffer[0, vSize - 1] =
            cells[0, vSize - 1] ?
                CountNeighborsBranch(0, vSize - 1) == 2 || CountNeighborsBranch(0, vSize - 1) == 3 :
                CountNeighborsBranch(0, vSize - 1) == 3;
        cellBuffer[hSize - 1, vSize - 1] =
            cells[hSize - 1, vSize - 1] ?
                CountNeighborsBranch(hSize - 1, vSize - 1) == 2 || CountNeighborsBranch(hSize - 1, vSize - 1) == 3 :
                CountNeighborsBranch(hSize - 1, vSize - 1) == 3;
    }

    private void StepEdges()
    {
        for (int x = 1; x < hSize - 1; x++)
        {
            cellBuffer[x, 0] =
                cells[x, 0] ?
                    CountNeighborsBranch(x, 0) == 2 || CountNeighborsBranch(x, 0) == 3 :
                    CountNeighborsBranch(x, 0) == 3;
            cellBuffer[x, vSize - 1] =
                cells[x, vSize - 1] ?
                    CountNeighborsBranch(x, vSize - 1) == 2 || CountNeighborsBranch(x, vSize - 1) == 3 :
                    CountNeighborsBranch(x, vSize - 1) == 3;
        }
        for (int y = 1; y < vSize - 1; y++)
        {
            cellBuffer[0, y] =
                cells[0, y] ?
                    CountNeighborsBranch(0, y) == 2 || CountNeighborsBranch(0, y) == 3 :
                    CountNeighborsBranch(0, y) == 3;
            cellBuffer[hSize - 1, y] =
                cells[hSize - 1, y] ?
                    CountNeighborsBranch(hSize - 1, y) == 2 || CountNeighborsBranch(hSize - 1, y) == 3 :
                    CountNeighborsBranch(hSize - 1, y) == 3;
        }
    }

    private byte CountNeighborsBranch(int x, int y)
    {
        byte result = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                if (x + i >= 0 && x + i < hSize && y + j >= 0 && y + j < vSize)
                    result += cells[x + i, y + j] ? (byte)1 : (byte)0;
            }
        }
        return result;
    }

    private byte CountNeighbors(int x, int y)
    {
        byte result = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                result += cells[x + i, y + j] ? (byte)1 : (byte)0;
            }
        }
        return result;
    }

    private void Step()
    {
        StepCorners();
        StepEdges();

        Parallel.For(1, hSize - 1, (x) =>
        {
            for (int y = 1; y < vSize - 1; y++)
            {
                byte n = CountNeighbors(x, y);
                cellBuffer[x, y] = cells[x, y] ? n == 2 || n == 3 : n == 3;
            }
        });

        for (int x = 0; x < hSize; x++)
        {
            for (int y = 0; y < vSize; y++)
            {
                cells[x, y] = cellBuffer[x, y];
                cellBuffer[x, y] = false;
            }
        }
    }

    private void Render()
    {
        Graphics g = Graphics.FromImage(imageBuffer);
        g.Clear(Color.Black);
        // Grid
        for (int x = 0; x <= hSize; x++)
            g.DrawLine(Pens.Gray, xOff + (float)(x * sqWidth), yOff, xOff + (float)(x * sqWidth), yOff + (float)(vSize * sqWidth));
        for (int y = 0; y <= vSize; y++)
            g.DrawLine(Pens.Gray, xOff, yOff + (float)(y * sqWidth), xOff + (float)(hSize * sqWidth), yOff + (float)(y * sqWidth));
        // cells
        for (int x = 0; x < hSize; x++)
        {
            for (int y = 0; y < vSize; y++)
            {
                if (cells[x, y])
                    g.FillRectangle(
                        Brushes.White,
                        xOff + (float)(x * sqWidth),
                        yOff + (float)(y * sqWidth),
                        sqWidth,
                        sqWidth
                    );
            }
        }
        canvas.Image = imageBuffer;
        canvas.Invalidate();

    }

    private void DimensionsChanged(object sender, EventArgs e)
    {
        hSize = (int)xDim.Value;
        vSize = (int)yDim.Value;
        bool[,] tempCells = new bool[hSize, vSize];
        cellBuffer = new bool[hSize, vSize];
        for (int x = 0; x < Math.Min(hSize, cells.GetLength(0)); x++)
            for (int y = 0; y < Math.Min(vSize, cells.GetLength(1)); y++)
                tempCells[x, y] = cells[x, y];
        cells = tempCells;
        CalculateMetric();
    }
}
