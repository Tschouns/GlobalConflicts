class Conflict
{
    constructor(conflictData)
    {
        // private member variables
        let data = conflictData;

        // public methods
        this.renderToCanvas = function(year)
        {
            if (year < data.StartYear ||
                year > data.EndYear)
            {
                return;
            }
    
            ellipse(data.PosX, data.PosY, 80, 80);
        }
    }
}