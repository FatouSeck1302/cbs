using System;
using doLittle.Domain;
using doLittle.Runtime.Events;
using Concepts;
using Events;
using System.Collections.Generic;

namespace Domain
{
    public class CaseReporting : AggregateRoot
    {
        public CaseReporting(EventSourceId eventSourceId) : base(eventSourceId)
        {
        }

        public void ReportInvalidReport(
            DataCollectorId collector,
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = collector,
                Origin = origin,
                Message = originalMessage,
                ErrorMessages = errorMessages,
                Timestamp = timestamp
            });
        }

        public void ReportInvalidReportFromUnknownDataCollector(
            string origin,
            string originalMessage,
            IEnumerable<string> errorMessages,
            DateTimeOffset timestamp)
        {
            Apply(new InvalidReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                Message = originalMessage,
                ErrorMessages = errorMessages,
                Timestamp = timestamp
            });

        }

        public void Report(
            Guid dataCollectorId,
            Guid healthRiskId,
            string origin,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            double longitude,
            double latitude,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportReceived
            {
                CaseReportId = EventSourceId,
                DataCollectorId = dataCollectorId,
                HealthRiskId = healthRiskId,
                Origin = origin,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder,
                Longitude = longitude,
                Latitude = latitude,
                Timestamp = timestamp
            });
        }        

        public void ReportFromUnknownDataCollector(
            string origin,
            Guid healthRiskId,
            int numberOfMalesUnder5,
            int numberOfMalesAged5AndOlder,
            int numberOfFemalesUnder5,
            int numberOfFemalesAged5AndOlder,
            DateTimeOffset timestamp)
        {
            Apply(new CaseReportFromUnknownDataCollectorReceived
            {
                CaseReportId = EventSourceId,
                Origin = origin,
                HealthRiskId = healthRiskId,
                NumberOfFemalesUnder5 = numberOfFemalesUnder5,
                NumberOfFemalesAged5AndOlder = numberOfFemalesAged5AndOlder,
                NumberOfMalesUnder5 = numberOfMalesUnder5,
                NumberOfMalesAged5AndOlder = numberOfMalesAged5AndOlder,
                Timestamp = timestamp
            });
        }      
        
        public void ReportFromUnknownDataCollectorIdentiefied(
            Guid DataCollectorId
            )
        {
            Apply(new CaseReportIdentified
            {
                CaseReportId = EventSourceId,
                DataCollectorId = DataCollectorId
            });
        }
    }
}