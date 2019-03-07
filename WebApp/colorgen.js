class ConflictColorGenerator
{
    constructor()
    {
        // private variables
        let hardColor;
        let softColor;

        setRandomColors();

        // public methods
        this.getHardColor = () => hardColor;
        this.getSoftColor = () => softColor;

        // private helper methods
        function setRandomColors()
        {
            let baseBrightness = 160;
            let maxOffset = 70;

            let r = baseBrightness + getRandomInt(-maxOffset, maxOffset);
            let g = baseBrightness + getRandomInt(-maxOffset, maxOffset);
            let b = baseBrightness + getRandomInt(-maxOffset, maxOffset);

            hardColor = color(r, g, b);
            softColor = color(r * 1.2, g * 1.2, b * 1.2);
        }

        function getRandomInt(min, max)
        {
            return Math.floor(Math.random() * (max - min) + min);
        }
    }
}