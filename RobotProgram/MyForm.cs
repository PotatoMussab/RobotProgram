using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;
using System.IO;
using System.Speech.Synthesis;
using System.Media;
using System.Diagnostics;

namespace RobotProgram
{
    public partial class MyForm : Form {
        SoundPlayer beep, ping;
        SpeechSynthesizer speech;
        SerialPort port;
        PrivateFontCollection pfc;
        System.IntPtr data;
        Panel pongPanel,reactPanel,menuPanel,maintenance;
        System.Windows.Forms.Timer pongTimer;
        System.Timers.Timer idleTimer,pulseTimer,reactTimer;
        Random rand = new Random();
        //StdSpd is the speed at which it takes 1 second for a pixel to cross the entire Form
        int stdSpdX,stdSpdY,ballX,ballY,pScore,cScore,cpuSpd,reactScore1,reactScore2;
        bool ballGoingLeft,moveDown,moveUp,runPong,runReact,portExists,vip,waitingForPress,acceptPress;
        string[] winQuotes =
        {
            "You got lucky this time",
            "I was just warming up",
            "This is unfair",
            "I let you win this time",
            "Well played",
            "Next time I won't go so easy",
            "Grow some fingers then challenge me again"
        };
        string[] loseQuotes =
        {
            "Bots are superior to men",
            "That was easy",
            "Too easy",
            "I wasn't even trying",
            "Clapped",
            "Are you sure you are pressing the correct buttons?",
            "Hahahahahahahahahaha"
        };
        string[] cScoreQuotes =
        {
            "Another point goes to the superbot",
            "Try to block the shot this time",
            "This isn't going well for you",
            "Try harder next time",
            "You need to react faster",
            "Give up already",
            "+1",
            "Another day another goal",
            "You are skilled at losing",
            "My engineers will be proud",
            "Pay me 5 dollars and I will let you win",
            "One more point and I will be able to afford a new motor",
            "My motors might be rusty, but my skills aren't",
            "That was close. Just kidding. It wasn't",
            "I now demonstrate my superior skills"
        };
        string[] pScoreQuotes =
        {
            "I can't believe you scored",
            "Oh no",
            "I wasn't looking",
            "I won't let you win this",
            "That was faster than my AI could handle",
            "If only my engineers programmed movement prediction",
            "Recalibrating",
            "How can I make my paddle move faster?",
            "Beginner's luck",
            "Reformulating Strategy. Just kidding. I am not that advanced",
            "How did you do that",
            "Please let me win. I have a family"
        };

        public MyForm()
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                port = new SerialPort(ports[0], 9600);
                try
                {
                    port.Open();
                    portExists = true;
                    port.DataReceived += dataReceived;
                }
                catch (IOException e)
                {
                    Console.WriteLine("Port will not open\n{0}", e);
                }
            }
            else portExists = false;
            menuPanel = new Panel();
            pongPanel = new Panel();
            reactPanel = new Panel();
            maintenance = new Panel();
            InitializeComponent();
            pongPanel.Controls.AddRange(new Control[] { cpu, player, ball, scoreLabel,messageLabel });
            menuPanel.Controls.AddRange(new Control[] { pongLabel,reactLabel,exitLabel});
            reactPanel.Controls.AddRange(new Control[] { p1Label, p1ScoreLabel, p2Label, p2ScoreLabel, goLabel, reactMessageLabel });
            maintenance.Controls.AddRange(new Control[] { distanceLabel, distanceField, colorField, colorButton, moveLeft, moveRight, headLeft, headRight, shakeHead });
            reactTimer = new System.Timers.Timer();
            reactTimer.Interval = rand.Next(2000, 5000);
            reactTimer.AutoReset = false;
            reactTimer.Enabled = false;
            reactTimer.Elapsed += reactTick;
            resetMaintenance();
            resetMenu();
            resetPongSizes();
            resetPongGame();
            resetReactionGame();
            InitFont();
            this.Controls.Add(pongPanel);
            this.Controls.Add(menuPanel);
            this.Controls.Add(reactPanel);
            this.Controls.Add(maintenance);
            reactPanel.Enabled = false;
            reactPanel.Visible = false;
            pongPanel.Enabled = false;
            pongPanel.Visible = false;
            menuPanel.Enabled = false;
            menuPanel.Visible = false;
            maintenance.Enabled = false;
            maintenance.Visible = false;
            moveDown = false;
            moveUp = false;
            runPong = false;
            runReact = false;
            vip = true;
            pulseTimer = new System.Timers.Timer();
            pulseTimer.Enabled = false;
            pulseTimer.AutoReset = false;
            idleTimer = new System.Timers.Timer();
            idleTimer.AutoReset = true;
            idleTimer.Interval = 10000;
            idleTimer.Elapsed += startIdleAnimation;
            idleTimer.Enabled = true;
            pongTimer = new System.Windows.Forms.Timer();
            pongTimer.Interval = 20;
            pongTimer.Enabled = true;
            pongTimer.Tick += timerTick;
            speech = new SpeechSynthesizer();
            speech.SelectVoice("Microsoft David Desktop");
            speech.SpeakAsync("I am alive");
            ping = new SoundPlayer(Properties.Resources.Blip);
            beep = new SoundPlayer(Properties.Resources.Beep);
        }
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = port.ReadExisting();
            if (data.Contains('r') && maintenance.Visible)
            {
                setText(colorField, "Red");
            }
            if (data.Contains('b') && maintenance.Visible)
            {
                setText(colorField, "Blue");
            }
            if (data.Contains('g') && maintenance.Visible)
            {
                setText(colorField, "Green");
            }
            if (data.Contains('d') && maintenance.Visible)
            {
                setText(distanceField, "YES");
            }
            if (data.Contains('n') && maintenance.Visible)
            {
                setText(distanceField, "NO");
            }
            if (data.Contains('d') && idlePic.Visible)
            {
                speech.SpeakAsync("Please place your card over the scanner");
                port.Write(new char[] { 'c' }, 0, 1);
            }
            if (data.Contains('r') && idlePic.Visible)
            {
                speech.SpeakAsync("Starting maintenance program");
                setVisible(lookingPic, false);
                setVisible(idlePic, false);
                idleTimer.Elapsed -= startIdleAnimation;
                setVisible(maintenance, true);
            }
            if (data.Contains('b')&&idlePic.Visible)
            {
                speech.SpeakAsync("Welcome user");
                port.Write(new char[] {'w'},0,1);
                vip = false;
                startIdleToMenu();
            }
            if (data.Contains('g')&&idlePic.Visible)
            {
                speech.SpeakAsync("Welcome VIP user");
                port.Write(new char[] { 'w' }, 0, 1);
                vip = true;
                startIdleToMenu();
            }
            if (data.Contains('n')&&idlePic.Visible)
            {
                speech.SpeakAsync("You seem to have left. Goodbye");
                port.Write(new char[] {'w'},0,1);
            }
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                moveUp = false;
            if (e.KeyData == Keys.Down)
                moveDown = false;
            if (e.KeyData == Keys.R && pongPanel.Visible)
            {
                resetPongGame();
                runPong = true;
            }
            if (e.KeyData == Keys.R && reactPanel.Visible)
            {
                resetReactionGame();
                runReact = true;
            }
            if (e.KeyData == Keys.Escape && pongPanel.Visible)
                startPongToMenu();
            if(e.KeyData ==Keys.Escape&&reactPanel.Visible)
                startReactToMenu();
            if (e.KeyData == Keys.Escape && maintenance.Visible)
            {
                setVisible(maintenance, false);
                setVisible(idlePic, true);
                setVisible(lookingPic, true);
                idleTimer.Elapsed += startIdleAnimation;
            }
            if (e.KeyData == Keys.Q && runReact)
            {
                if (reactScore1 < 3 && reactScore2 < 3)
                    setVisible(goLabel, false);
                if (waitingForPress&&acceptPress)
                {
                    reactScore1++;
                    acceptPress = false;
                    pulseTimer.Interval = 500;
                    pulseTimer.Elapsed += reactGrace;
                }
                if(!waitingForPress&&acceptPress)
                {
                    reactScore2++;
                    acceptPress = false;
                    pulseTimer.Interval = 500;
                    pulseTimer.Elapsed += reactGrace;
                }
                waitingForPress = false;
                setVisible(goLabel, false);
                resetReactionPanel();
                if (reactScore1 > 2)
                {
                    goLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 80);
                    goLabel.Text = "Player 1 Wins";
                    setVisible(goLabel,true);
                    p1ScoreLabel.ForeColor = Color.Red;
                    runReact = false;
                    speech.SpeakAsync("Player 1 Wins");
                    if (portExists)
                        port.Write(new char[] {'r','t'},0,2);
                }
                if (reactScore2 > 2)
                {
                    goLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 80);
                    goLabel.Text = "Player 2 Wins";
                    setVisible(goLabel,true);
                    p2ScoreLabel.ForeColor = Color.Red;
                    runReact = false;
                    speech.SpeakAsync("Player 2 Wins");
                    if (portExists)
                        port.Write(new char[] { 'l', 't' }, 0, 2);
                }
                resetReactionPanel();
            }
            if (e.KeyData == Keys.P && runReact)
            {
                if (reactScore1 < 3 && reactScore2 < 3)
                    setVisible(goLabel, false);
                if (waitingForPress&&acceptPress)
                {
                    reactScore2++;
                    acceptPress = false;
                    pulseTimer.Interval = 500;
                    pulseTimer.Elapsed += reactGrace;
                }
                if(!waitingForPress&&acceptPress)
                {
                    reactScore1++;
                    acceptPress = false;
                    pulseTimer.Interval = 500;
                    pulseTimer.Elapsed += reactGrace;
                }
                waitingForPress = false;
                if (reactScore1 > 2)
                {
                    goLabel.Font = new Font(pfc.Families[0], reactPanel.Width/80);
                    goLabel.Text = "Player 1 Wins";
                    setVisible(goLabel, true);
                    p1ScoreLabel.ForeColor = Color.Red;
                    runReact = false;
                }
                if (reactScore2 > 2)
                {
                    goLabel.Font = new Font(pfc.Families[0], reactPanel.Width/80);
                    goLabel.Text = "Player 2 Wins"
                        ;
                    setVisible(goLabel, true);
                    p2ScoreLabel.ForeColor = Color.Red;
                    runReact = false;
                }
                    resetReactionPanel();
            }
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                moveUp = true;
            if (e.KeyData == Keys.Down)
                moveDown = true;
        }
        private void reactGrace(object sender, ElapsedEventArgs e)
        {
            acceptPress = true;
            pulseTimer.Elapsed -= reactGrace;
            reactTimer.Start();
        }
        private void reactTick(object sender, EventArgs e)
        {
            if (runReact)
            {
                if(!waitingForPress)
                beep.Play();
                setVisible(goLabel, true);
                waitingForPress = true;
                reactTimer.Interval = rand.Next(2000, 5000);
            }
        }
        private void timerTick(object sender, EventArgs e)
        {
            if (runPong)
            {
                if (ball.Top <= 0 || ball.Bottom >= pongPanel.Height)
                    ballY = -ballY;
                if (ball.Left <= 0)
                {
                    cScore++;
                    if (cScore < 3)
                    speech.SpeakAsync(cScoreQuotes[rand.Next(cScoreQuotes.Length)]);
                    resetPongPositions();
                }
                if (ball.Right >= pongPanel.Width)
                {
                    pScore++;
                    if(pScore<3)
                    speech.SpeakAsync(pScoreQuotes[rand.Next(pScoreQuotes.Length)]);
                    resetPongPositions();
                }
                if (cScore > 2)
                {
                    scoreLabel.Text = "CPU Wins";
                    scoreLabel.Left = pongPanel.Width / 2 - scoreLabel.Width / 2;
                    runPong = false;
                    if(portExists)
                        port.Write(new char[] { 's' }, 0, 1);
                    speech.SpeakAsync(loseQuotes[rand.Next(loseQuotes.Length)]);
                }
                if (pScore > 2)
                {
                    scoreLabel.Text = "Player Wins";
                    scoreLabel.Left = pongPanel.Width / 2 - scoreLabel.Width / 2;
                    runPong = false;
                    if (portExists)
                        port.Write(new char[] {'t'},0,1);
                    speech.SpeakAsync(winQuotes[rand.Next(winQuotes.Length)]);
                }
                if (ball.Top + (ball.Height / 2) > cpu.Top + (cpu.Height / 2) && cpu.Bottom < pongPanel.Height)
                    cpuSpd = -stdSpdY / 2;
                else if (ball.Top + (ball.Height / 2) < cpu.Top + (cpu.Height / 2) && cpu.Top > 0)
                    cpuSpd = stdSpdY / 2;
                else
                    cpuSpd = 0;
                if (ball.Bounds.IntersectsWith(player.Bounds) && ballGoingLeft)
                {
                    ping.Play();
                    ballX = -ballX + stdSpdX / 15;
                    ballGoingLeft = false;
                    if (moveUp)
                        ballY += stdSpdY / 4;
                    if (moveDown)
                        ballY -= stdSpdY / 4;
                }
                if (ball.Bounds.IntersectsWith(cpu.Bounds) && (!ballGoingLeft))
                {
                    ping.Play();
                    ballX = -ballX - stdSpdX / 15;
                    ballGoingLeft = true;
                    ballY += cpuSpd / 2;
                }
                if (moveUp && player.Top > 0)
                    player.Top -= stdSpdY / 2;
                if (moveDown && player.Bottom < pongPanel.Height)
                    player.Top += stdSpdY / 2;
                ball.Top -= ballY;
                ball.Left += ballX;
                cpu.Top -= cpuSpd;
            }
        }
        private void startIdleToMenu()
        {
            setVisible(idlePic, false);
            setVisible(lookingPic, false);
            setVisible(inTransPic, true);
            idleTimer.Enabled = false;
            pulseTimer.Interval = 5000;
            pulseTimer.Elapsed += endIdleToMenu;
            pulseTimer.Start();
        }
        private void startIdleToMenu(object sender, EventArgs e)
        {
            startIdleToMenu();
        }
        private void endIdleToMenu(object sender, ElapsedEventArgs e)
        {
            setVisible(inTransPic, false);
            setVisible(menuPanel, true);
            setVisible(reactLabel, vip);
            pulseTimer.Elapsed -= endIdleToMenu;
        }
        private void startMenuToIdle(object sender, EventArgs e)
        {
            setVisible(menuPanel, false);
            setVisible(outTransPic, true);
            pulseTimer.Interval = 500;
            pulseTimer.Elapsed += endMenuToIdle;
            pulseTimer.Start();
        }
        private void endMenuToIdle(object sender, ElapsedEventArgs e)
        {
            setVisible(outTransPic, false);
            setVisible(idlePic, true);
            idleTimer.Enabled = true;
            pulseTimer.Elapsed -= endMenuToIdle;
        }
        private void startMenuToPong(object sender, EventArgs e)
        {
            speech.SpeakAsync("Use the arrow keys to move your paddle.");
            setVisible(menuPanel, false);
            setVisible(outTransPic, true);
            resetPongGame();
            pulseTimer.Interval = 500;
            pulseTimer.Elapsed += endMenuToPong;
            pulseTimer.Start();
        }

        private void endMenuToPong(object sender, ElapsedEventArgs e)
        {
            setVisible(outTransPic,false);
            setVisible(pongPanel, true);
            runPong = true;
            pulseTimer.Elapsed -= endMenuToPong;
        }
        private void startPongToMenu()
        {
            speech.SpeakAsyncCancelAll();
            speech.SpeakAsync("That was fun");
            runPong = false;
            setVisible(pongPanel, false);
            setVisible(outTransPic, true);
            resetMenu();
            pulseTimer.Interval = 500;
            pulseTimer.Elapsed += endPongToMenu;
            pulseTimer.Start();
        }
        private void endPongToMenu(object sender, ElapsedEventArgs e)
        {
            setVisible(outTransPic, false);
            setVisible(menuPanel, true);
            setVisible(reactLabel, vip);
            pulseTimer.Elapsed -= endPongToMenu;
        }
        private void startMenuToReact(object sender, EventArgs e)
        {
            speech.SpeakAsync("Player 1 should press Q when signalled. Player 2 should press P when signalled. Whoever reacts faster to the signal wins.");
            setVisible(menuPanel, false);
            setVisible(outTransPic,true);
            runReact=true;
            resetReactionGame();
            pulseTimer.Elapsed += endMenuToReact;
            pulseTimer.Interval = 500;
            pulseTimer.Start();
        }
        private void endMenuToReact(object sender,ElapsedEventArgs e)
        {
            setVisible(outTransPic, false);
            setVisible(reactPanel, true);
            setVisible(goLabel, false);
            pulseTimer.Elapsed -= endMenuToReact;
        }
        private void startReactToMenu()
        {
            speech.SpeakAsyncCancelAll();
            speech.SpeakAsync("I hope you had fun");
            setVisible(reactPanel, false);
            setVisible(outTransPic, true);
            pulseTimer.Elapsed += endReactToMenu;
            pulseTimer.Interval = 500;
            pulseTimer.Start();
        }

        private void endReactToMenu(object sender, ElapsedEventArgs e)
        {
            setVisible(outTransPic, false);
            setVisible(menuPanel, true);
            pulseTimer.Elapsed -= endReactToMenu;
            runReact = false;
            waitingForPress = false;
        }
        private void startIdleAnimation(object sender, ElapsedEventArgs e)
        {
            setVisible(lookingPic,true);
            pulseTimer.Interval = 5000;
            pulseTimer.Elapsed += endIdleAnimation;
            pulseTimer.Start();
        }
        private void endIdleAnimation(object sender, ElapsedEventArgs e)
        {
            setVisible(lookingPic, false);
            pulseTimer.Elapsed -= endIdleAnimation;
        }
        private void resetPongPositions()
        {
            player.Top = 2 * pongPanel.Height / 5;
            cpu.Top = 2 * pongPanel.Height / 5;
            player.Left = pongPanel.Width / 25;
            cpu.Left = 23 * pongPanel.Width / 25;
            ball.Left = 12*pongPanel.Width/25;
            ball.Top = 12 * pongPanel.Height / 25;
            scoreLabel.Text=""+pScore+"-"+cScore;
            scoreLabel.Left = pongPanel.Width / 2 - scoreLabel.Width / 2;
            scoreLabel.Top = 0;
            messageLabel.Top = pongPanel.Height - messageLabel.Height;
            messageLabel.Left = pongPanel.Width / 2 - messageLabel.Width / 2;
            ballX = stdSpdX/2;
            int randInt = rand.Next(-2, 2) * 4;
            if (randInt != 0)
                ballY = stdSpdY / randInt;
            else
                ballY = 0;
            ballGoingLeft = false;
        }
        private void resetPongSizes()
        {
            pongPanel.Top = 0;
            pongPanel.Left = 0;
            pongPanel.Size = this.Size;
            player.Height = pongPanel.Height / 5;
            player.Width = pongPanel.Width / 25;
            cpu.Height = pongPanel.Height / 5;
            cpu.Width = pongPanel.Width /25;
            ball.Height = pongPanel.Height / 25;
            ball.Width = pongPanel.Height / 25;
            stdSpdX = pongPanel.Width / 50;
            stdSpdY = pongPanel.Height / 50;
        }
        private void resetPongGame()
        {
            cScore = 0;
            pScore = 0;
            resetPongPositions();
            cpuSpd = 0;
        }
        private void resetMenu()
        {
            menuPanel.Left = 0;
            menuPanel.Top = 0;
            menuPanel.Size = this.Size;
            pongLabel.Top = 0;
            reactLabel.Top = pongLabel.Height+20;
            exitLabel.Top = menuPanel.Height - exitLabel.Height;
            exitLabel.Left = 0;
            pongLabel.Left = 0;
            reactLabel.Left = 0;
        }
        private void resetReactionPanel()
        {
            reactPanel.Top = 0;
            reactPanel.Left = 0;
            reactPanel.Size = this.Size;
            p1ScoreLabel.Text = "" + reactScore1;
            p2ScoreLabel.Text = "" + reactScore2;
            p1ScoreLabel.Top = reactPanel.Height / 2 - p1ScoreLabel.Height / 2;
            p2ScoreLabel.Top = reactPanel.Height / 2 - p2ScoreLabel.Height / 2;
            p1Label.Top = p1ScoreLabel.Top - p1Label.Height;
            p2Label.Top = p2ScoreLabel.Top - p2Label.Height;
            p1Label.Left = 0;
            p1ScoreLabel.Left = 0;
            p2Label.Left = reactPanel.Width - p2Label.Width;
            p2ScoreLabel.Left = reactPanel.Width - p2ScoreLabel.Width;
            goLabel.Top = reactPanel.Height / 2 - goLabel.Height / 2;
            goLabel.Left = reactPanel.Width / 2 - goLabel.Width / 2;
            reactMessageLabel.Left= reactPanel.Width / 2 - reactMessageLabel.Width / 2;
            reactMessageLabel.Top = reactPanel.Height - reactMessageLabel.Height;
        }
        private void resetReactionGame()
        {
            reactScore1 = 0;
            reactScore2 = 0;
            goLabel.Font = new Font(pfc.Families[0], this.Width / 10);
            goLabel.Text = "Go!";
            p1ScoreLabel.ForeColor = Color.White;
            p2ScoreLabel.ForeColor = Color.White;
            resetReactionPanel();
            reactTimer.Start();
            setVisible(goLabel, false);
            waitingForPress = false;
            acceptPress = true;
        }
        private void resetMaintenance()
        {
            maintenance.Top = 0;
            maintenance.Left = 0;
            maintenance.Size = this.Size;
            moveLeft.Top = 0;
            moveLeft.Left = 0;
            moveRight.Top = maintenance.Height / 3;
            moveRight.Left = 0;
            shakeHead.Left = 0;
            shakeHead.Top = 2 * maintenance.Height / 3;
            colorButton.Top = 0;
            colorButton.Left = maintenance.Width / 3;
            colorField.Top = maintenance.Height / 3;
            colorField.Left = maintenance.Width / 3;
            headLeft.Top = 2 * maintenance.Height / 3;
            headLeft.Left = maintenance.Width / 3;
            distanceLabel.Top = 0;
            distanceLabel.Left = 2 * maintenance.Width / 3;
            distanceField.Top = maintenance.Height / 3;
            distanceField.Left = 2* maintenance.Width / 3;
            headRight.Top = 2 * maintenance.Height / 3;
            headRight.Top = 2 * maintenance.Width / 3;
            moveLeft.Width = maintenance.Width / 3;
            moveRight.Width = maintenance.Width / 3;
            headLeft.Width = maintenance.Width / 3;
            headRight.Width = maintenance.Width / 3;
            shakeHead.Width = maintenance.Width / 3;
            distanceLabel.Width = maintenance.Width / 3;
            distanceField.Width = maintenance.Width / 3;
            colorButton.Width = maintenance.Width / 3;
            colorField.Width = maintenance.Width / 3;
            moveLeft.Height = maintenance.Height / 3;
            moveRight.Height = maintenance.Height / 3;
            headLeft.Height = maintenance.Height / 3;
            headRight.Height = maintenance.Height / 3;
            shakeHead.Height = maintenance.Height / 3;
            distanceField.Height = maintenance.Height / 3;
            distanceLabel.Height = maintenance.Height / 3;
            colorButton.Height = maintenance.Height / 3;
            colorField.Height = maintenance.Height / 3;
        }
        private void moveLeftArm(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] {'t'},0,1);
        }
        private void moveRightArm(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] { 'w' }, 0, 1);
        }
        private void moveHeadRight(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] { 'r' }, 0, 1);
        }
        private void moveHeadLeft(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] { 'l' }, 0, 1);
        }
        private void headShake(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] { 's' }, 0, 1);
        }
        private void readColor(object sender, EventArgs e)
        {
            if (portExists)
                port.Write(new char[] { 'c' }, 0, 1);
        }
        private void formResized(object sender, EventArgs e)
        {
            resetMaintenance();
            resetPongSizes();
            resetPongPositions();
            resetMenu();
            resetReactionPanel();
            InitFont();
            idlePic.Top = 0;
            idlePic.Left = 0;
            outTransPic.Top = 0;
            outTransPic.Left = 0;
            inTransPic.Top = 0;
            inTransPic.Left = 0;
            lookingPic.Top = 0;
            lookingPic.Left = 0;
            idlePic.Size = this.Size;
            outTransPic.Size = this.Size;
            inTransPic.Size = this.Size;
            lookingPic.Size = this.Size;
        }
        private void InitFont()
        {
            pongPanel.Top = 0;
            pongPanel.Left = 0;
            pongPanel.Size = this.Size;
            reactPanel.Top = 0;
            reactPanel.Left = 0;
            reactPanel.Size = this.Size;
            menuPanel.Left = 0;
            menuPanel.Top = 0;
            menuPanel.Size = this.Size;
            pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.emulogic.Length;
            byte[] fontdata = Properties.Resources.emulogic;
            data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            scoreLabel.Font = new Font(pfc.Families[0], pongPanel.Width/20);
            messageLabel.Font= new Font(pfc.Families[0], pongPanel.Width/100);
            pongLabel.Font = new Font(pfc.Families[0], menuPanel.Width / 50);
            reactLabel.Font = new Font(pfc.Families[0], menuPanel.Width / 50);
            exitLabel.Font = new Font(pfc.Families[0], menuPanel.Width / 50);
            p1Label.Font = new Font(pfc.Families[0], reactPanel.Width / 80);
            p2Label.Font = new Font(pfc.Families[0], reactPanel.Width / 80);
            p1ScoreLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 10);
            p2ScoreLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 10);
            goLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 10);
            reactMessageLabel.Font = new Font(pfc.Families[0], reactPanel.Width / 100);
        }
        private delegate void SetTextCallBack(TextBox c, string text);
        private delegate void SetVisibleCallBack(Control c,bool visible);
        private void setVisible(Control c, bool visible)
        {
            if (c.InvokeRequired)
                this.Invoke(new SetVisibleCallBack(setVisible),new object[] {c,visible});
            else
            {
                c.Enabled = visible;
                c.Visible = visible;
            }
        }
        private void setText(TextBox t,string text)
        {
            if (t.InvokeRequired)
                this.Invoke(new SetTextCallBack(setText), new object[] { t, text });
            else
                t.Text = text;
        }
    }
}
