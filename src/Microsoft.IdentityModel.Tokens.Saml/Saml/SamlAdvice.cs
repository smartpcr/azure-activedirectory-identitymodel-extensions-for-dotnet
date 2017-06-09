//------------------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.IdentityModel.Logging;

namespace Microsoft.IdentityModel.Tokens.Saml
{
    /// <summary>
    /// Represents the Advice element specified in [Saml, 2.3.2.2].
    /// </summary>
    /// <remarks>
    /// This information MAY be ignored by applications without affecting either
    /// the semantics or the validity of the assertion.
    /// </remarks>
    public class SamlAdvice
    {
        private Collection<string> _assertionIdReferences = new Collection<string>();
        private Collection<SamlAssertion> _assertions = new Collection<SamlAssertion>();


        /// <summary>
        /// Creates an instance of SamlAdvice.
        /// </summary>
        public SamlAdvice()
            : this(null, null)
        {
        }

        /// <summary>
        /// Creates an instance of SamlAdvice.
        /// </summary>
        /// <param name="references">saml ID list</param>
        public SamlAdvice(Collection<string> references)
            : this(references, null)
        {
        }

        /// <summary>
        /// Creates an instance of SamlAdvice.
        /// </summary>
        /// <param name="assertions"><see cref="SamlAssertion"/></param>
        public SamlAdvice(Collection<SamlAssertion> assertions)
            : this(null, assertions)
        {
        }

        /// <summary>
        /// Creates an instance of SamlAdvice.
        /// </summary>
        /// <param name="references">Saml ID list</param>
        /// <param name="assertions"><see cref="SamlAssertion"/></param>
        public SamlAdvice(Collection<string> references, Collection<SamlAssertion> assertions)
        {
            if (references != null)
            {
                foreach (var idReference in references)
                {
                    if (idReference == null)
                        throw LogHelper.LogExceptionMessage(new SecurityTokenException("SAMLEntityCannotBeNullOrEmpty"));

                    _assertionIdReferences.Add(idReference);
                }
            }

            if (assertions != null)
            {
                foreach (SamlAssertion assertion in assertions)
                {
                    if (assertion == null)
                        throw LogHelper.LogExceptionMessage(new SecurityTokenException("SAMLAssertionCannotBeNullOrEmpty"));

                    _assertions.Add(assertion);
                }
            }
        }

        /// <summary>
        /// Gets a collection of <see cref="Uri"/> representing the assertions in the <see cref="SamlAdvice"/>.
        /// </summary>
        public Collection<string> AssertionIdReferences
        {
            get { return _assertionIdReferences; }
        }


        /// <summary>
        /// Gets a collection of <see cref="SamlAssertion"/> representating the assertions in the <see cref="SamlAdvice"/>.
        /// </summary>
        public Collection<SamlAssertion> Assertions
        {
            get { return _assertions; }
        }
    }
}

