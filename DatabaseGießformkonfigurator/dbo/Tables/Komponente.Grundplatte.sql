CREATE TABLE [dbo].[Komponente.Grundplatte] (
    [SAP-Nr.]                   INT             NOT NULL,
    [Bezeichnung_RoCon]         VARCHAR (255)   NULL,
    [Außendurchmesser]          DECIMAL (10, 2) NOT NULL,
    [Innendurchmesser]          DECIMAL (10, 2) NOT NULL,
    [Toleranz_Innendurchmesser] VARCHAR (10)    NULL,
    [Hoehe]                     DECIMAL (10, 2) NOT NULL,
    [Konus_Hoehe]               DECIMAL (10, 2) NOT NULL,
    [Konus_Außen_Max]           DECIMAL (10, 2) NOT NULL,
    [Konus_Außen_Min]           DECIMAL (10, 2) NOT NULL,
    [Konus_Außen_Winkel]        DECIMAL (5, 2)  NOT NULL,
    [mit_Konusfuehrung]         BIT             NOT NULL,
    [Konus_Innen_Max]           DECIMAL (10, 2) NULL,
    [Konus_Innen_Min]           DECIMAL (10, 2) NULL,
    [Konus_Innen_Winkel]        DECIMAL (5, 2)  NULL,
    [mit_Lochfuehrung]          BIT             NOT NULL,
    [mit_Kern]                  BIT             NOT NULL,
    CONSTRAINT [PK_Komponente.Grundplatte] PRIMARY KEY CLUSTERED ([SAP-Nr.] ASC)
);

