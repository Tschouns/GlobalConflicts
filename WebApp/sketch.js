
let sketchCanvas;
let statusDiv;

// Sketch variables.
let conflicts;
let state;

function setup()
{
    try
    {
        // Get div handles.
        statusDiv = document.getElementById('status');
        outputDiv = document.getElementById('output');

        // Create canvas.
        let parentDiv = document.getElementById('conflicts');
        let width = parentDiv.offsetWidth;
        let height = parentDiv.offsetHeight;

        sketchCanvas = createCanvas(width, height);
        sketchCanvas.parent("conflicts");

        initializeSketch();
    }
    catch(error)
    {
        alert(error.message); 
    }
}

function draw()
{
    try
    {
        updateSketch();
        drawSketch();
    }
    catch(error)
    {
        alert(error.message); 
    }
}

function initializeSketch()
{
    conflicts = createConflictArray(conflictData);
    // Initialize state variables.
    state =
    {
        year: 1400,
    };
}

function updateSketch()
{
    state.year++;
}

function drawSketch()
{
    clear();
    conflicts.forEach(conflict =>
    {
        conflict.renderToCanvas(state.year);
    });
}

function createConflictArray(conflictData)
{
    let conflictArray = Array();
    conflictData.forEach(element => 
    {
        conflictArray.push(new Conflict(element));
    });

    return conflictArray;
}

function setStatus(text)
{
    statusDiv.value = text;
}
