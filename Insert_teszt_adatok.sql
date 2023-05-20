USE [infomix]
GO
SET IDENTITY_INSERT [dbo].[BNOk] ON 

INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (2, N'A0000', N'Kolera (Vibrio cholerae 01)')
INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (3, N'A0100', N'Hastífusz (typhus abdominalis)')
INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (4, N'A0200', N'Salmonella bélhurut')
INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (5, N'A0510', N'Botulizmus')
INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (6, N'A0800', N'Rotavírus bélhurut')
INSERT [dbo].[BNOk] ([BNOId], [BNOKod], [BetegsegNeve]) VALUES (7, N'R05H0', N'Köhögés')
SET IDENTITY_INSERT [dbo].[BNOk] OFF
GO
SET IDENTITY_INSERT [dbo].[Paciensek] ON 

INSERT [dbo].[Paciensek] ([PaciensId], [Nev], [Cim], [Szuletesnap], [TAJ]) VALUES (1, N'Józsi', N'Kiskunfélegyháza', CAST(N'2020-01-01T00:00:00.0000000' AS DateTime2), N'111222333')
INSERT [dbo].[Paciensek] ([PaciensId], [Nev], [Cim], [Szuletesnap], [TAJ]) VALUES (2, N'Géza', N'Szekszárd', CAST(N'1980-01-01T00:00:00.0000000' AS DateTime2), N'555444333')
INSERT [dbo].[Paciensek] ([PaciensId], [Nev], [Cim], [Szuletesnap], [TAJ]) VALUES (3, N'Aladár', N'Alabama', CAST(N'1960-01-01T00:00:00.0000000' AS DateTime2), N'999666999')
SET IDENTITY_INSERT [dbo].[Paciensek] OFF
GO
SET IDENTITY_INSERT [dbo].[Receptek] ON 

INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (7, CAST(N'2023-05-31T12:34:56.0000000' AS DateTime2), N'Józsefnek kiállítva Kolera ellen', 0, 0, 0, 0, 0, 1, 1, 2)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (8, CAST(N'2023-05-31T15:05:00.0000000' AS DateTime2), N'Szekszárdi Gézának - Tífuszra', 0, 0, 0, 0, 0, 1, 2, 3)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (9, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül kolerára', 0, 0, 0, 0, 0, 1, 3, 2)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (10, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül tifuszra', 0, 0, 0, 0, 0, 1, 3, 3)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (11, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül szalmonellára', 0, 0, 0, 0, 0, 1, 3, 4)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (12, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül Botulizmusra', 0, 0, 0, 0, 0, 1, 3, 5)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (13, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül Rotavirusra', 0, 0, 0, 0, 0, 1, 3, 6)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (14, CAST(N'2023-05-31T15:07:00.0000000' AS DateTime2), N'Aladárnak sok betegésge közül Rotavirusra', 0, 0, 0, 0, 0, 1, 3, 6)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (16, CAST(N'2023-05-20T17:43:46.4778535' AS DateTime2), N'Aladarnak Rotavirusra', 0, 0, 0, 0, 0, 0, 3, 6)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (17, CAST(N'2023-05-20T18:45:15.6312938' AS DateTime2), N'Aladarnak náthás megfázásos köhögés csillapítására (modositva)', 0, 0, 0, 0, 0, 0, 3, 7)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (18, CAST(N'2023-05-20T17:45:59.0148319' AS DateTime2), N'Aladarnak Rotavirusra', 0, 0, 0, 0, 0, 0, 3, 6)
INSERT [dbo].[Receptek] ([ReceptId], [ReceptKiallitasDatuma], [ReceptSzovege], [AltalanosJogcimmel], [Kozgyogyellatottnak], [EURendelkezessel], [EUTeritesKotelesAronRendelve], [TeljesAronRendelve], [Helyettesitheto], [PaciensId], [BNOId]) VALUES (19, CAST(N'2023-05-20T17:46:00.5494030' AS DateTime2), N'Aladarnak Rotavirusra', 0, 0, 0, 0, 0, 0, 3, 6)
SET IDENTITY_INSERT [dbo].[Receptek] OFF
GO
