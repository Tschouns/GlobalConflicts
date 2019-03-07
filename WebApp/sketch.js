let slider;
let yearDiv;
let sketchCanvas;

// Sketch variables.
let conflicts;
let clock;
let state;

// p5 setup and draw

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
    clock = new Clock();

    // Initialize state variables.
    state =
    {
        speed: 0,
        year: 1400,
    };
}

function updateSketch()
{
    clock.update();
    updateYearSlider();
}

function drawSketch()
{
    clear();
    conflicts.forEach(conflict =>
    {
        conflict.renderToCanvas(state.year);
    });

    yearDiv.innerHTML = state.year;
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

function updateYearSlider()
{
    state.year = state.year + state.speed * clock.getTimePassed() / 1000; // ...because milliseconds.
    if (state.year > 2000)
    {
        state.year = 2000;
    }
}

// Event handlers

function onSliderValueChanged()
{
    state.year = Number(slider.value);
}

function onPauseButtonClick()
{
    state.speed = 0;
}

function onPlayButtonClick()
{
    state.speed = 0.2;
}

function onFastForwardButtonClick()
{
    state.speed = 1;
}

function onVeryFastForwardButtonClick()
{
    state.speed = 5;
}