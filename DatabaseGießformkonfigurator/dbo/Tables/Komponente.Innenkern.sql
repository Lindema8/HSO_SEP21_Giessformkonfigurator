CREATE TABLE [dbo].[Komponente.Innenkern] (
    [SAP-Nr.]                       INT             NOT NULL,
    [Durchmesser]                   DECIMAL (10, 2) NOT NULL,
    [Toleranz_Durchmesser]          VARCHAR (10)    NULL,
    [Hoehe]                         DECIMAL (10, 2) NOT NULL,
    [Gießhohe_Max]                  DECIMAL (10, 2) NOT NULL,
    [mit_Konusfuehrung]             BIT             NOT NULL,
    [Konus_Außen_Max]               DECIMAL (10, 2) NULL,
    [Konus_Außen_Min]               DECIMAL (10, 2) NULL,
    [Konus_Außen_Winkel]            DECIMAL (5, 2)  NULL,
    [Konus_Hoehe]                   DECIMAL (10, 2) NULL,
    [mit_Fuehrungsstift]            BIT             NOT NULL,
    [Hoehe_Fuehrung]                DECIMAL (10, 2) NOT NULL,
    [Durchmesser_Fuehrung]          DECIMAL (10, 2) NOT NULL,
    [Toleranz_Durchmesser_Fuehrung] DECIMAL (10, 2) NOT NULL,
    [mit_Lochfuehrung]              BIT             NULL,
    [Durchmesser_Adapter]           DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Komponente.Innenkern] PRIMARY KEY CLUSTERED ([SAP-Nr.] ASC)
);

