using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class Form1 : Form
    {
        char[,] data;
        char nextTurn;
        int padding = 50;
        bool gameStopped = false;
        int winnerType = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            nextTurn = 'x';
            data = new char[,]
            {
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
            };
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int supposedHeight = h - 2 * padding;
            int supposedWidth = w - 2 * padding;
            int size;
            if (supposedHeight > supposedWidth)
            {
                size = supposedWidth;
            }
            else
            {
                size = supposedHeight;
            }
            int left = (w - size) / 2;
            int top = (h - size) / 2;
            g.DrawRectangle(Pens.Black, left, top, size, size);
            for (int i = 0; i <= 3; i++)
            {
                int y = top + i * size / 3;
                g.DrawLine(Pens.Red, left, y, left + size, y);
            }
            using (Font f = new Font(Font.FontFamily, 30))
            {
                for (int i = 0; i <= 3; i++)
                {
                    int x = left + i * size / 3;
                    g.DrawLine(Pens.Yellow, x, top, x, top + size);
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        char c = data[i, j];
                        int x = left + j * size / 3;
                        int y = top + i * size / 3;
                        int s = size / 3;
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        g.DrawString(c.ToString(),
                            f, Brushes.Black,
                            new RectangleF(x, y, s, s),
                            sf);

                    }
                }
            }
            if (winnerType > 0)
            {
                int s = size / 3;
                Pen LinePen = new Pen(Color.Red, 3);
                if (winnerType >= 1 && winnerType <= 3)
                {
                    int LineInd = winnerType - 1;
                    int LineTop = top + s * LineInd + s / 2;
                    g.DrawLine(LinePen, left, LineTop, left + size, LineTop);
                }
                else if (winnerType >= 4 && winnerType <= 6)
                {
                    int LineInd = winnerType - 4;
                    int LineLeft = left + s * LineInd + s / 2;
                    g.DrawLine(LinePen, LineLeft, top, LineLeft, top + size);
                } else if (winnerType == 7)
                {
                    g.DrawLine(LinePen, left, top, left + size, top + size);
                } else if (winnerType == 8)
                {
                    g.DrawLine(LinePen, left, top + size, left + size, top);
                }
                LinePen.Dispose();
            }
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameStopped)
            {
                return;
            }
            int x = e.X;
            int y = e.Y;
            int w = ClientSize.Width;
            int h = ClientSize.Height;
            int supposedHeight = h - 2 * padding;
            int supposedWidth = w - 2 * padding;
            int size;
            if (supposedHeight > supposedWidth)
            {
                size = supposedWidth;
            }
            else
            {
                size = supposedHeight;
            }
            int left = (w - size) / 2;
            int top = (h - size) / 2;
            if (x - left < 0 || y - top < 0)
            {
                return;
            }
            int s = size / 3;
            int column = (x - left) / s;
            int row = (y - top) / s;
            makeTurn(column, row);
        }
        private bool makeTurn(int column, int row) {
            if (column > 2 || row > 2)
            {
                return false;
            }
            if (data[row, column] != ' ')
            {
                return false;
            }
            data[row, column] = nextTurn;
            getWinner();
            if (nextTurn == 'x')
            {
                nextTurn = 'o';
            }
            else
            {
                nextTurn = 'x';
            }
            if (nextTurn == 'o') {
                startTerminator();
            }
            Invalidate();
            return true;
        }
        private void startTerminator()
        {
            if (gameStopped)
            {
                return;
            }
            while (true)
            {
                int column = rnd.Next(3);
                int row = rnd.Next(3);
                bool success = makeTurn(column, row);
                if (success)
                {
                    break;
                }
            }
        }

        private void getWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (data[i, 0] == ' ')
                {
                    continue;
                }
                if (data[i, 0] == data[i, 1]
                    && data[i, 0] == data[i, 2])
                {
                    winnerType = i + 1;
                    gameStopped = true;
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (data[0, i] == ' ')
                {
                    continue;
                }
                if (data[0, i] == data[1, i]
                    && data[0, i] == data[2, i])
                {
                    winnerType = i + 4;
                    gameStopped = true;
                    return;
                }
            }
            if (data[0, 0] != ' ')
            {
                if (data[0, 0] == data[1, 1]
                    && data[0, 0] == data[2, 2])
                {
                    winnerType = 7;
                    gameStopped = true;
                    return;
                }
            }
            if (data[0, 2] != ' ')
            {
                if (data[0, 2] == data[1, 1]
                && data[0, 2] == data[2, 0])

                {
                    winnerType = 8;
                    gameStopped = true;
                    return;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (data[i, j] == ' ')
                    {
                        return;
                    }
                }
            }
            gameStopped = true;
        }

        private void btnAgain_Click(object sender, EventArgs e)
        {
            nextTurn = 'x';
            data = new char[,]
            {
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
                {' ', ' ', ' ' },
            };
            gameStopped = false;
            winnerType = 0;
            Invalidate();
        }
        private Dictionary<string, AnalysisResult> analysis;

        private void button1_Click(object sender, EventArgs e)
        {
            string data = "         ";
            analysis = new Dictionary<string, AnalysisResult>();
            determineResult(data, 'x');
        }
        private AnalysisResult determineResult(string data, char turn)
        {
            if (analysis.ContainsKey(data))
            {
                return analysis[data];
            }
            char[,] dataConverted = convertData(data);
            char winner = getWinnerV2(dataConverted);
            if (winner != '?')
            {
                var res = new AnalysisResult();
                if (winner == 'x')
                {
                    res.xWinnerCount = 1;
                }else if (winner == 'o')
                {
                    res.xWinnerCount = 1;
                }
                else
                {
                    res.drawCount = 1;
                }
                analysis[data] = res;
                return res;
            }
            var result = new AnalysisResult();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != ' ')
                {
                    continue;
                }
                string newData = data.Substring(0, i)
                    + turn + data.Substring(i + 1);
                var subRes = determineResult(newData,
                    turn == 'x' ? 'o' : 'x');
                result.xWinnerCount += subRes.xWinnerCount;
                result.oWinnerCount += subRes.oWinnerCount;
                result.drawCount += subRes.drawCount;
            }
            analysis[data] = result;
            return result;
        }

        private char[,] convertData(string data)
        {
            char[,] res = new char[3, 3];
            for (int i = 0; i < data.Length; i++)
            {
                int row = i / 3;
                int column = i % 3;
                res[row, column] = data[i];
            }
            return res;
        }

        private char getWinnerV2(char[,] data)
        {
            for (int i = 0; i < 3; i++)
            {
                if (data[i, 0] == ' ')
                {
                    continue;
                }
                if (data[i, 0] == data[i, 1]
                    && data[i, 0] == data[i, 2])
                {
                    return data[i, 0];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (data[0, i] == ' ')
                {
                    continue;
                }
                if (data[0, i] == data[1, i]
                    && data[0, i] == data[2, i])
                {
                    return data[0, i];
                }
            }
            if (data[0, 0] != ' ')
            {
                if (data[0, 0] == data[1, 1]
                    && data[0, 0] == data[2, 2])
                {
                    return data[0, 0];
                }
            }
            if (data[0, 2] != ' ')
            {
                if (data[0, 2] == data[1, 1]
                && data[0, 2] == data[2, 0])

                {
                    return data[0, 2];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (data[i, j] == ' ')
                    {
                        return '?';
                    }
                }
            }
            return '!';
        }
    }
}

