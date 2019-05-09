namespace ImageEditor.Constants
{
    public static class ControlConstants
    {
        public const string TextPropertyName = ".Text";
        public const string FormTextResourceString = "$this.Text";

        #region [Brightness/Contrast]

        public const string BrightnessContrastFormName = "BrightnessContrast";

        public const int MinBrightness = -100;
        public const int DefaultBrightness = 0;
        public const int MaxBrightness = 100;

        public const int MinContrast = -100;
        public const int DefaultContrast = 0;
        public const int MaxContrast = 100;

        #endregion

        #region [Threshold]

        public const string ThresholdFormName = "Threshold";

        public const int MinThresholdLevel = 0;
        public const int DefaultThresholdLevel = 128;
        public const int MaxThresholdLevel = 255;

        #endregion

        #region [Color Balance]

        public const string ColorBalanceFilterFormName = "ColorBalance";

        public const int MinColorBalance = -100;
        public const int DefaultColorBalance = 0;
        public const int MaxColorBalance = 100;

        #endregion

        #region [Exposure]

        public const string ExposureFormName = "Exposure";

        public const int MinGamma = 1;
        public const int DefaultGamma = 400;
        public const int MaxGamma = 799;

        public const int MinExposure = -200;
        public const int DefaultExposure = 0;
        public const int MaxExposure = 200;

        #endregion

        #region [Custom Filter]

        public const string CustomFilterFormName = "CustomFilter";

        #endregion
    }
}
