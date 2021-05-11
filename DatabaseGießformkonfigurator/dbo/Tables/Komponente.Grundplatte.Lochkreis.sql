CREATE TABLE [dbo].[Komponente.Grundplatte.Lochkreis] (
    [SAP-Nr.]          INT             NOT NULL,
    [LK-Nr.]           CHAR (4)        NOT NULL,
    [Anzahl_Bohrungen] INT             NOT NULL,
    [Gewinde]          VARCHAR (4)     NOT NULL,
    [Position]         DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_Komponente.Grundplatte.Lochkreis] PRIMARY KEY CLUSTERED ([SAP-Nr.] ASC),
    CONSTRAINT [FK_Komponente.Grundplatte.Lochkreis_Komponente.Grundplatte] FOREIGN KEY ([SAP-Nr.]) REFERENCES [dbo].[Komponente.Grundplatte] ([SAP-Nr.])
);

