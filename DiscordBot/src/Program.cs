using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "MzYxNjY2OTUxODk2MTA0OTYy.DKncLA.pu6WUjDFSFJFI7331ThYXu29GkM",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "g."
            });

            commands.RegisterCommands<Commands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
