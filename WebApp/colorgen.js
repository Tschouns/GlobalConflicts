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
            let maxOffset = 60;
            let softFactor = 1.3;

            let r = baseBrightness + getRandomInt(-maxOffset, maxOffset);
            let g = baseBrightness + getRandomInt(-maxOffset, maxOffset);

            let remainingSpan = 2 * maxOffset - Math.abs(r - g);
            let bOffset = (r + g - 2 * baseBrightness) < 0 ? remainingSpan : -remainingSpan;

            let b = baseBrightness + bOffset;

            hardColor = color(r, g, b);
            softColor = color(r * softFactor, g * softFactor, b * softFactor);
        }

        function getRandomInt(min, max)
        {
            return Math.floor(Math.random() * (max - min) + min);
        }
    }
}