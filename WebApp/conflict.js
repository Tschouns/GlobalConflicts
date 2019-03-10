class Conflict
{
    constructor(conflictData)
    {
        // private member variables
        let data = conflictData;

        let maxTotalDiameter = maxCircleDiameter(data.NumberOfFatalities);
        let maxMilDiameter = maxCircleDiameter(data.NumberOfMilitaryFatalities);
        
        if (maxTotalDiameter < 60)
        {
            maxTotalDiameter = 60;
        }

        let colorGen = new ConflictColorGenerator();

        let currentTotalDiameter = 0;
        let currentMilDiameter = 0;
        let isActive = false;
        let isCursorHoveringConflict = false;

        // public methods
        this.getCommonName = () => { return data.CommonName; }
        this.getSummary = () => { return data.Summary; }
        this.getStartYear = () => { return data.StartYear; }
        this.getEndYear = () => { return data.EndYear; }
        this.getNumberOfFatalities = () => {return data.NumberOfFatalities; }

        this.update = function(year)
        {
            // check status.
            isActive = checkIsActive(year);
            isCursorHoveringConflict = checkIsCursorHoveringConflict();

            // update circle diameter.
            if (!isActive)
            {
                currentTotalDiameter = 0;
                currentMilDiameter = 0;
                return;
            }

            let progressFactor = (year - data.StartYear) / (data.EndYear - data.StartYear + 1);
            currentTotalDiameter = maxTotalDiameter * progressFactor;
            currentMilDiameter = maxMilDiameter * progressFactor;
        }

        this.drawToCanvas = function(highlight)
        {
            if (!isActive)
            {
                return;
            }

            let strokeColor = highlight ? colorGen.getHardHighlightColor() : colorGen.getHardColor();
            let fillColor = highlight ? colorGen.getSoftHighlightColor() : colorGen.getSoftColor();
    
            data.Actors.forEach(actor =>
                {
                    drawActorLine(data.PosX, data.PosY, actor.PosX, actor.PosY, fillColor);
                });

            drawCircle(strokeColor, fillColor);

            data.Actors.forEach(actor =>
                {
                    drawActorFlag(actor.PosX, actor.PosY, strokeColor, fillColor);
                });
        }

        this.checkHover = function()
        {
            return isActive && isCursorHoveringConflict;
        }

        // private helper methods
        function checkIsActive(year)
        {
            if (year < data.StartYear ||
                year > data.EndYear)
            {
                return false;
            }

            return true;
        }

        function checkIsCursorHoveringConflict()
        {
            let a = Math.abs(mouseX - data.PosX);
            let b = Math.abs(mouseY - data.PosY);

            let c = Math.sqrt(a * a + b * b);

            return c < (currentTotalDiameter / 2);
        }

        function drawCircle(strokeColor, fillColor)
        {
            // main circle
            strokeWeight(5);
            stroke(strokeColor);
            fill(fillColor);
            ellipse(data.PosX, data.PosY, currentTotalDiameter, currentTotalDiameter);

            // inner circle (for military fatalities)
            noStroke();
            fill(strokeColor);
            ellipse(data.PosX, data.PosY, currentMilDiameter, currentMilDiameter);
        }

        function drawActorLine(pos1X, pos1Y, pos2X, pos2Y, color)
        {
            strokeWeight(3);
            stroke(color);

            line(pos1X, pos1Y, pos2X, pos2Y);
        }

        function drawActorFlag(posX, posY, strokeColor, fillColor)
        {
            let flagSize = 15;
            let flagPostHeight = 40;

            stroke(strokeColor);
            fill(fillColor);

            strokeWeight(3);
            rect(posX, posY - flagPostHeight, flagSize, flagSize);
            
            strokeWeight(2);
            line(posX, posY - flagPostHeight, posX, posY);
        }

        function maxCircleDiameter(numberOfFatalities)
        {
            let scale = 0.2;
            let diameter = Math.sqrt(numberOfFatalities / Math.PI) * 2 * scale;

            return diameter;
        }
    }
}