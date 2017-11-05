using System;
using System.IO;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        #region Private
        private static DiscordClient discord;
        private static CommandsNextModule commands;
        private static InteractivityModule interactivity;
        private static VoiceNextClient voice;
        #endregion

        #region Public
        public static string OutputFolder = $"{Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar}videos";
        #endregion

        static void Main (string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync (string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "YOUR_KEY_HERE",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            interactivity = discord.UseInteractivity();

            voice = discord.UseVoiceNext ();

            commands = discord.UseCommandsNext (new CommandsNextConfiguration
            {
                StringPrefix = "g."
            });

            commands.RegisterCommands<Commands> ();

            await discord.ConnectAsync ();
            await Task.Delay (-1);
        }
    }
}
