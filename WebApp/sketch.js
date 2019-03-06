let slider;
let yearDiv;
let sketchCanvas;

// Sketch variables.
let conflicts;
let state;

// p5 setup - draw
function setup()
{
    try
    {
        // Get element handles.
        slider = document.getElementById('slider');
        yearDiv = document.getElementById('yearDiv');

        // Create canvas.
        let parentDiv = document.getElementById('conflictsDiv');
        let width = parentDiv.offsetWidth;
        let height = parentDiv.offsetHeight;

        sketchCanvas = createCanvas(width, height);
        sketchCanvas.parent("conflictsDiv");

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

// Sketch functions

function initializeSketch()
{
    conflicts = createConflictArray(conflictData);
    // Initialize state variables.
    state =
    {
        year: 1400.00,
    };
}

function updateSketch()
{
    //state.year++;
}

function drawSketch()
{
    clear();
    conflicts.forEach(conflict =>
    {
        conflict.renderToCanvas(state.year);
    });
}

// Helper functions

function createConflictArray(conflictData)
{
    let conflictArray = Array();
    conflictData.forEach(element => 
    {
        conflictArray.push(new Conflict(element));
    });

    return conflictArray;
}

// Event handlers
function onSliderValueChanged()
{
    state.year = slider.value;
    yearDiv.innerHTML = state.year;
}
