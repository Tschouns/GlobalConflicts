class Clock
{
    constructor()
    {
        // private member variables
        let timeRunning = millis();
        let timeRunningBefore = timeRunning;
        let timePassed = 0;

        // public methods
        this.update = function()
        {
            let time = millis();
        };

        this.getTimePassed = function()
        {
            return timePassed;
        };
    }
}