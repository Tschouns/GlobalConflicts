class Conflict
{
    constructor(conflictData)
    {
        // private member variables
        let data = conflictData;
        let maxTotalDiameter = maxCircleDiameter(data.NumberOfFatalities);
        let strokeColor = color(200, 100, 100);
        let fillColor = color(250, 150, 150);

        // public methods
        this.renderToCanvas = function(year)
        {
            if (year < data.StartYear ||
                year > data.EndYear)
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
        function drawCircle(year)
        {
            let progressFactor = (year - data.StartYear) / (data.EndYear - data.StartYear);
            let diameter = maxTotalDiameter * progressFactor;

            strokeWeight(5);
            stroke(strokeColor);
            fill(fillColor);

            ellipse(data.PosX, data.PosY, diameter, diameter);
        }

        function drawActorLine(pos1X, pos1Y, pos2X, pos2Y)
        {
            strokeWeight(3);
            stroke(strokeColor);

            line(pos1X, pos1Y, pos2X, pos2Y);
        }

        function drawActorFlag(posX, posY)
        {
            let flagSize = 15;
            let flagPostHeight = 40;

            strokeWeight(5);
            stroke(strokeColor);
            fill(fillColor);

            line(posX, posY - (flagPostHeight - flagSize), posX, posY);
            rect(posX, posY - flagPostHeight, flagSize, flagSize);
        }

        function maxCircleDiameter(numberOfFatalities)
        {
            let min = 50;
            let scale = 0.2;

            let diameter = Math.sqrt(numberOfFatalities / Math.PI) * 2 * scale;

            return diameter > min ? diameter : min;
        }
    }
}