function setup()
{
    var parentDiv = document.getElementById('conflicts');
    var width = parentDiv.offsetWidth;
    var height = parentDiv.offsetHeight;

    var sketchCanvas = createCanvas(width, height);
    sketchCanvas.parent("conflicts");
    
    // sketchCanvas.background(255, 100, 100);
}

function draw()
{
    background(255, 255, 100);
}