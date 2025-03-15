public class DraggablePictureBox : PictureBox
{
    private bool isDragging = false;
    private Point offset;

    public DraggablePictureBox()
    {
        this.SizeMode = PictureBoxSizeMode.StretchImage;
        this.MouseDown += OnMouseDown;
        this.MouseMove += OnMouseMove;
        this.MouseUp += OnMouseUp;
    }

    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            offset = e.Location;
        }
    }

    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            this.Left += e.X - offset.X;
            this.Top += e.Y - offset.Y;
        }
    }

    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }
}
