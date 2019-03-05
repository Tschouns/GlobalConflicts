class Conflict
{
    constructor(conflictData)
    {
        this.data = conflictData;
    }

    renderToCanvas(year)
    {
        if (year < this.data.StartYear ||
            year > this.data.EndYear)
        {
            return;
        }

        ellipse(this.data.PosX, this.data.PosY, 80, 80);
    }
}