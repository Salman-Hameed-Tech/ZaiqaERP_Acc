using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Drawing.Imaging;
/* 
 * ***************************************************
 *                 Barcode Library                   *
 *                                                   *
 *             Written by: Brad Barnhill             *
 *                   Date: 09-21-2007                *
 *          Last Modified: 12-01-2011                *
 *                                                   *
 *  This library was designed to give developers an  *
 *  easy class to use when they need to generate     *
 *  barcode images from a string of data.            *
 * ***************************************************
 */
namespace BarcodeLib
{
    #region Enums
    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended, Codabar, PostNet, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, ITF14, CODE93, TELEPEN, FIM };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
    public enum AlignmentPositions : int { CENTER, LEFT, RIGHT};
    public enum LabelPositions : int { TOPLEFT, TOPCENTER, TOPRIGHT, BOTTOMLEFT, BOTTOMCENTER, BOTTOMRIGHT };
    #endregion
    /// <summary>
    /// Generates a barcode image of a specified symbology from a string of data.
    /// </summary>
   
}//Barcode namespace
