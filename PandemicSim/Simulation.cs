using System;
using System.Collections.Generic;
using System.Linq;

namespace PandemicSim
{
    /// <summary>
    /// Class responsible for the simulation run.
    /// </summary>
    public class Simulation
    {
        /// <summary>
        /// The Random Number Generator
        /// </summary>
        private readonly Random rng;

        /// <summary>
        /// The simulation's options.
        /// </summary>
        private readonly Options simOptions;

        /// <summary>
        /// The simulation's grid.
        /// </summary>
        private readonly Grid simGrid;

        /// <summary>
        /// The simulation's agents.
        /// </summary>
        private readonly Agent[] agents;

        /// <summary>
        /// Flag indicating if any agent is still alive.
        /// </summary>
        private bool IsAnyAgentAlive => agents.Length > DeadAgentCount;

        /// <summary>
        /// Number of healthy agents.
        /// </summary>
        private int HealthyAgentCount => agents.Length
                                         - InfectedAgentCount
                                         - DeadAgentCount;

        /// <summary>
        /// Number of infected agents.
        /// </summary>
        private int InfectedAgentCount => agents.Where(x => x.IsDead == false && 
                                                          x.IsInfected == true)
                                                .Count();

        /// <summary>
        /// Number of dead agents.
        /// </summary>
        private int DeadAgentCount => agents.Where(x => x.IsDead == true)
                                            .Count();

        /// <summary>
        /// Creates a new instance of <see cref="Simulation"/>.
        /// </summary>
        /// <param name="options">The game's options.</param>
        public Simulation(Options options)
        {
            rng = new Random();

            simOptions = options;

            simGrid = new Grid(simOptions.GridSize);

            agents = new Agent[simOptions.AgentInitialCount];

            SetupAgents();
        }

        /// <summary>
        /// The main simulation run loop.
        /// </summary>
        public void Run()
        {
            string holder;
            List<TurnReport> turnReports;
            TurnReport turnReport;

            turnReports = new List<TurnReport>();

            if (!simOptions.ShowSimulation)
            {
                Console.WriteLine($"Simulation starts with {agents.Length} " +
                                   "healthy agents.");
            }

            for (int roundCounter = 1; roundCounter <= simOptions.MaxTurns; 
                                       roundCounter++)
            {
                // For every Agents...
                for (int k = 0; k < agents.Length; k++)
                {
                    if (!agents[k].IsDead)
                    {
                        // ...randomly move them.
                        simGrid.RandomlyMoveAgent(rng, agents[k]);

                        // If infected...
                        if (agents[k].IsInfected)
                        {
                            // ...spread the virus.
                            agents[k].TileRef.SpreadVirus(roundCounter);

                            // Performs infection tick
                            agents[k].InfectionTick(roundCounter);
                        }
                    }
                }

                // First infection
                if (simOptions.FirstInfectionTurn == roundCounter)
                {
                    int randomAgent = rng.Next(0, agents.Length);

                    agents[randomAgent].Infect(roundCounter);
                }

                if (!simOptions.ShowSimulation)
                {
                    holder = $"Turn {roundCounter}: ";
                    holder += $"{HealthyAgentCount} healthy, ";
                    holder += $"{InfectedAgentCount} infected ";
                    holder += $"and {DeadAgentCount} dead.";

                    Console.WriteLine(holder);
                }

                // If user asked to generate stats file
                if (simOptions.OutputSimulationToFile)
                {
                    turnReport = new TurnReport(HealthyAgentCount,
                                            InfectedAgentCount,
                                            DeadAgentCount);

                    turnReports.Add(turnReport);
                }

                if (!IsAnyAgentAlive)
                    break;
            }

            // TODO Save file if user asked for it
        }

        /// <summary>
        /// Randomly setup all agents on the grid.
        /// </summary>
        private void SetupAgents()
        {
            for (int i = 0; i < agents.Length; i++)
            {
                int row, column;

                agents[i] = new Agent(i, simOptions.InfectedLifeSpan);

                row = rng.Next(0, simOptions.GridSize);
                column = rng.Next(0, simOptions.GridSize);

                simGrid.PlaceAgent(agents[i], row, column);
            }
        }
    }
}
