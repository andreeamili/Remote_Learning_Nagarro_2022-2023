using System;
using System.Collections.Generic;
using iQuest.VendingMachine.PresentationLayer;
using iQuest.VendingMachine.Exeptions;
using iQuest.VendingMachine.Exceptions;

namespace iQuest.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();

                IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                try
                {
                    useCase.Execute();
                }
                catch (Exception e) when (e is CancelExeption)
                {
                    Console.WriteLine(e.Message);

                }
                catch (Exception e) when (e is InvalidColumnIdException || e is OutOfStockException)
                {
                    mainView.DisplayError(e.Message);

                }
                catch (Exception e) when (e is InvalidCardException)
                {
                    mainView.DisplayError(e.Message);

                }
                catch (Exception e) when (e is FormatException)
                {
                    mainView.DisplayError(e.Message);
                }
                catch(Exception e)when (e is NotEnoughMoneyException)
                {
                    mainView.DisplayError(e.Message);
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}