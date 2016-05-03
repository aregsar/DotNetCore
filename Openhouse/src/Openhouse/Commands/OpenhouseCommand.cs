using Openhouse.RequestModels;
using Openhouse.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Openhouse.Commands
{
    public class OpenhouseCommand
    {
        readonly Settings _settings;

        public OpenhouseCommand(Settings settings)
        {
            _settings = settings;
        }

        public class OpenhouseCommandResult
        {
            public int Result { get; set; } = 0;
            public OpenhouseViewModel EffectedOpenhouse { get; set; }
        }

        public OpenhouseCommandResult AddOpenhouse(OpenhousePost openhouse)
        {
            if(_settings.ReadWriteMode)
                return new OpenhouseCommandResult();

            throw new InvalidOperationException("ReadonlyMode Supported");
        }

        public OpenhouseCommandResult UpdateOpenhouse(OpenhousePut openhouse)
        {
            if (_settings.ReadWriteMode)
                return new OpenhouseCommandResult();

            throw new InvalidOperationException("ReadonlyMode Supported");
        }


        public OpenhouseCommandResult DeleteOpenhouse(int openhouseId)
        {
            if (_settings.ReadWriteMode)
                return new OpenhouseCommandResult();

            throw new InvalidOperationException("ReadonlyMode Supported");
        }
    }
}
