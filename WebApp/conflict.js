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
        let strokeColor = colorGen.getHardColor();
        let fillColor = colorGen.getSoftColor();

        let currentDiameter = 0;
        let isActive = false;

        // public methods
        this.renderToCanvas = function(year)
        {
            isActive = checkIsActive(year);

            if (!isActive)
            {
                return;
            }
    
            data.Actors.forEach(actor =>
                {
                    drawActorLine(data.PosX, data.PosY, actor.PosX, actor.PosY);
                });

            drawCircle(year);

            data.Actors.forEach(actor =>
                {
                    drawActorFlag(actor.PosX, actor.PosY);
                });
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

        function drawCircle(year)
        {
            let progressFactor = (year - data.StartYear) / (data.EndYear - data.StartYear);
            
            currentDiameter = maxTotalDiameter * progressFactor;
            
            // main circle
            strokeWeight(5);
            stroke(strokeColor);
            fill(fillColor);

            ellipse(data.PosX, data.PosY, currentDiameter, currentDiameter);

            // inner circle (for military fatalities)
            noStroke();
            fill(strokeColor);
            ellipse(data.PosX, data.PosY, maxMilDiameter * progressFactor, maxMilDiameter * progressFactor);
        }

        function drawActorLine(pos1X, pos1Y, pos2X, pos2Y)
        {
            strokeWeight(3);
            stroke(fillColor);

            line(pos1X, pos1Y, pos2X, pos2Y);
        }

        function drawActorFlag(posX, posY)
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