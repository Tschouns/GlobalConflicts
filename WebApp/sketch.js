
let sketchCanvas;
let state;

function setup()
{
    let parentDiv = document.getElementById('conflicts');
    let width = parentDiv.offsetWidth;
    let height = parentDiv.offsetHeight;

    sketchCanvas = createCanvas(width, height);
    sketchCanvas.parent("conflicts");
    
    state =
    {
        pos: 0
    };
    // sketchCanvas.background(255, 100, 100);
}

function draw()
{
    clear();

    state.pos++;
    // if (state.pos > 800)
    // {
    //     state.pos = 0;
    // }

    ellipse(state.pos, 900, 80, 80);
}