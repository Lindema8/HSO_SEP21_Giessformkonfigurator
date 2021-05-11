CREATE TABLE [dbo].[Komponente.Ringe] (
    [SAP-Nr.]                   INT             NOT NULL,
    [Bezeichnung_RoCon]         VARCHAR (255)   NOT NULL,
    [Außendurchmesser]          DECIMAL (10, 2) NOT NULL,
    [Toleranz_Außendurchmesser] DECIMAL (10, 2) NULL,
    [Innendurchmesser]          DECIMAL (10, 2) NOT NULL,
    [Toleranz_Innendurchmesser] VARCHAR (10)    NULL,
    [Hoehe]                     DECIMAL (10, 2) NOT NULL,
    [Gießhoehe_Max]             DECIMAL (10, 2) NOT NULL,
    [mit_Konusfuehrung]         BIT             NOT NULL,
    [Konus_Max]                 DECIMAL (10, 2) NULL,
    [Konus_Min]                 DECIMAL (10, 2) NULL,
    [Konus_Winkel]              DECIMAL (10, 2) NULL,
    [Konus_Hoehe]               DECIMAL (10, 2) NULL,
    [ohne_Konusfuehrung]        BIT             NOT NULL,
    CONSTRAINT [PK_Komponente.Ringe] PRIMARY KEY CLUSTERED ([SAP-Nr.] ASC)
);

