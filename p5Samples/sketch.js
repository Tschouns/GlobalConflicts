var pos = 0;

function setup()
{
    createCanvas(400, 400);
}

function draw()
{
    background(100);
    pos = pos + 1;
    if (pos > 400)
    {
        pos = 0;
    }

    ellipse(pos, pos, 80, 80);
}