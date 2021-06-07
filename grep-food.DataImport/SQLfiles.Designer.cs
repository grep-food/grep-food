﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace grep_food.DataImport {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SQLfiles {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SQLfiles() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("grep_food.DataImport.SQLfiles", typeof(SQLfiles).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE [dbo].[BaseIngredients] (
        ///    [Id]   UNIQUEIDENTIFIER NOT NULL,
        ///    [Name] NVARCHAR (255)    NOT NULL,
        ///    CONSTRAINT [PK_BaseIngredients] PRIMARY KEY CLUSTERED ([Id] ASC)
        ///);
        ///
        ///.
        /// </summary>
        internal static string BaseIngredients {
            get {
                return ResourceManager.GetString("BaseIngredients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE [dbo].[Ingredients] (
        ///    [Id]                UNIQUEIDENTIFIER CONSTRAINT [DF_Ingredients_Id] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
        ///    [BaseIngredient_ID] UNIQUEIDENTIFIER NOT NULL,
        ///    [FullName]          NVARCHAR (255)    NOT NULL,
        ///    CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC),
        ///    CONSTRAINT [FK_Ingredients_BaseIngredients] FOREIGN KEY ([BaseIngredient_ID]) REFERENCES [dbo].[BaseIngredients] ([Id])
        ///);
        ///
        ///.
        /// </summary>
        internal static string Ingredients {
            get {
                return ResourceManager.GetString("Ingredients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE [dbo].[RecipeIngredients] (
        ///    [RecipeId]     UNIQUEIDENTIFIER NOT NULL,
        ///    [IngredientId] UNIQUEIDENTIFIER NOT NULL,
        ///    CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED ([RecipeId] ASC, [IngredientId] ASC),
        ///    CONSTRAINT [FK_RecipeIngredients_RecipeIngredients] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredients] ([Id]),
        ///    CONSTRAINT [FK_RecipeIngredients_Recipes] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipes] ([Id])
        ///);
        ///
        ///.
        /// </summary>
        internal static string RecipeIngredients {
            get {
                return ResourceManager.GetString("RecipeIngredients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE [dbo].[Recipes] (
        ///    [Id]           UNIQUEIDENTIFIER NOT NULL,
        ///    [Name] NVARCHAR(256) NOT NULL, 
        ///    [TimeMinutes]         INT       NOT NULL,
        ///    [Instructions] NVARCHAR (MAX)    NOT NULL,
        ///    [Image] NVARCHAR(256) NULL,
        ///    
        ///    CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED ([Id] ASC)
        ///);
        ///
        ///.
        /// </summary>
        internal static string Recipes {
            get {
                return ResourceManager.GetString("Recipes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO [dbo].[Recipes]
        ///           ([Id]
        ///           ,[Name]
        ///           ,[TimeMinutes]
        ///           ,[Instructions]
        ///           ,[Image])
        ///     VALUES
        ///           (CAST(&apos;f78b879b-39c8-42d0-8381-ad54b943d592&apos; AS UNIQUEIDENTIFIER)
        ///           ,N&apos;Eastern European Kotlety&apos;
        ///           ,&apos;40&apos;
        ///           ,N&apos;Mix ground beef, cracker crumbs, onion, egg, milk, garlic, kosher salt, and black pepper in a large bowl until evenly blended. Shape meat mixture into twelve 3-inch patties about 1 1/4-inch thick.
        ///Heat vegetable sh [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ScriptsIgnoredOnImport {
            get {
                return ResourceManager.GetString("ScriptsIgnoredOnImport", resourceCulture);
            }
        }
    }
}
