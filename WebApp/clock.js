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
            timePassed = timeRunning - timeRunningBefore;
            timeRunningBefore = timeRunning;
            timeRunning = millis();
        };

        this.getTimePassed = function()
        {
            return timePassed;
        };
    }
}