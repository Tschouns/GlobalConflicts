class ConflictColorGenerator
{
    constructor()
    {
        // private variables
        let hardColor;
        let softColor;
        let hardHighlightColor;
        let softHighlightColor;

        setRandomColors();

        // public methods
        this.getHardColor = () => hardColor;
        this.getSoftColor = () => softColor;
        this.getHardHighlightColor = () => hardHighlightColor;
        this.getSoftHighlightColor = () => softHighlightColor;

        // private helper methods
        function setRandomColors()
        {
            let baseBrightness = 160;
            let maxOffset = 60;
            let softFactor = 1.3;
            let highlightFactor = 1.3;

            let r = baseBrightness + getRandomInt(-maxOffset, maxOffset);
            let g = baseBrightness + getRandomInt(-maxOffset, maxOffset);

            let remainingSpan = 2 * maxOffset - Math.abs(r - g);
            let bOffset = (r + g - 2 * baseBrightness) < 0 ? remainingSpan : -remainingSpan;

            let b = baseBrightness + bOffset;

            hardColor = color(r, g, b);
            softColor = color(r * softFactor, g * softFactor, b * softFactor);

            hardHighlightColor = color(
                r * highlightFactor,
                g * highlightFactor,
                b * highlightFactor);
                
            softHighlightColor = color(
                r * softFactor * highlightFactor,
                g * softFactor * highlightFactor,
                b * softFactor * highlightFactor);
        }

        function getRandomInt(min, max)
        {
            return Math.floor(Math.random() * (max - min) + min);
        }
    }
}