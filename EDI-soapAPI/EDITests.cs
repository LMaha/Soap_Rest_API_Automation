using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Configuration;
using SoapService;
using SoapService.Entities;
using EDI_soapAPI;
using EDI_soapAPI.Entities.LoadRestResponse;
using EDI_soapAPI.Entities;


namespace EDI_soapAPI
{
    [TestFixture]
    [Parallelizable]
    public class EDITests : BaseTest
    {

		public CustResponse _cust;
		public SoapService.ResponseEntities.Envelope response,response1,response2,response3;
		public string fn; 
		public string ln;
		public string email;
		public string cphno;
		public string compName;
		public List<EDI_soapAPI.Entities.Contact> _contacts;
		public List<EDI_soapAPI.Entities.CustomerNote> _cutomerNotes;
		public List<EDI_soapAPI.Entities.BillToAddress> _billtoaddress;
		public List<EDI_soapAPI.Entities.CustomerLocation> _customerLocations;

	[SetUp]
        public void Setup()
        {
			fn ="AutoConFirst" + Random.RandomString(3);
			ln = "AutoConLast" + Random.RandomString(3).ToString();
			email = "AutoEmail" + Random.RandomString(3).ToString() + "@test.com";
			cphno = "2222222222";
			compName = "AutoEDICompName" + Random.RandomString(3).ToString() + Random.RandomNumber(3).ToString();
			_contacts = new List<EDI_soapAPI.Entities.Contact>()
				{
					new EDI_soapAPI.Entities.Contact()
					{
						firstName =fn,
						lastName =ln,
						contactPhoneNum = cphno,
						emailId =email,
						active=true

					}
				};		
			_cutomerNotes = new List<EDI_soapAPI.Entities.CustomerNote>()
				{
					new EDI_soapAPI.Entities.CustomerNote()
					{
						noteTypes= new EDI_soapAPI.Entities.NoteTypes()
						{
							id ="4",
							name ="Customer Notes"

						}

					},
					new EDI_soapAPI.Entities.CustomerNote()
					{
						noteTypes= new EDI_soapAPI.Entities.NoteTypes()
						{
							id ="5",
							name ="Internal Customer Notes"
						}
					}
				};
			_billtoaddress = new List<EDI_soapAPI.Entities.BillToAddress>()
				{
					new EDI_soapAPI.Entities.BillToAddress()
					{
						companyName = compName,
						countryName ="United States of America",
						countryCode="USA",
						invoiceAfter="Delivery",
						invoiceBatchBilling=false,
						invoiceCurrency= "USD",
						invoiceFormat="PDF",
						invoiceStyle="Transactional",
						creditOverride=true,
						creditOverrideDate=DateTime.Today,
						auditMarginBelowPct=0,
						auditMarginAbovePct=70,
						auditMarginAboveAmt=1500,
						active=true,
						invoiceSettings=null,
						isIndividualEmail =false,
						deliveryMethod = new EDI_soapAPI.Entities.DeliveryMethod()
						{
							id="1"
						},
						bolSignature = null,
						podSignature=null,
						verifyCostBeforeInvoice =false,
						increasedCreditAmount =0,
						paymentTerms =new EDI_soapAPI.Entities.PaymentTerms()
						{
							id ="1",
							name="Pre-Paid"

						},
						creditAmount=0,
						availableCredit =0,
						availableCreditOld=0,
						contactFirstName=fn,
						contactLastName=ln,
						contactPhone = cphno,
						contactEmail=email,
						address1="134 main st",
						cityStateZipSearch ="WOODCLIFF, NJ, 07047",
						city="WOODCLIFF",
						//stateName="NJ",
						stateCode ="NJ",
						zipCode="07047",
						legacyAxAccountNumber="TB1234-12341",
						invoiceDocuments = new List<object>(),
						invoiceRequiredFields=new List<object>(),
						invoiceVerifiedFields=new List<object>(),
						frequencyType =null,
						dateOfInvoice=null,
						portal = null,
						previousCreditOverride=true

					}

				};
			_customerLocations = new List<EDI_soapAPI.Entities.CustomerLocation>()
				{
					new EDI_soapAPI.Entities.CustomerLocation()
					{
						active =true,
						salesReps= new List<object>(){ },
						lnErr =false,
						locationName ="WareHouse",
						primSalesRep = new EDI_soapAPI.Entities.PrimSalesRep()
						{
							id =1
						},
						commissionable =false,
						customerBillAddress = new EDI_soapAPI.Entities.CustomerBillAddress()
						{
							companyName = compName
						},
						ex1Error =false,
						primStartDate="01/01/2020",
						glCoding = new EDI_soapAPI.Entities.GlCoding()
						{
							plsOffice = new EDI_soapAPI.Entities.PlsOffice()
							{
								id ="2"
							},
							plsDivision = new EDI_soapAPI.Entities.PlsDivision()
							{
								id ="2"
							}
						},
						companyCode="FS",
						costCenter="PITT1",
						primary=true
						
					}
				};
			InitializeService(GetToken(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]));
			_cust = CreateNewCustomer();
			
		}


		[Test]
		[Description("Verify EDI load can be created and load exceptions can be cleared.")]
		public void ClearEDILoadException()
		{
			response = HttpMethods.XmlDeserialize<SoapService.ResponseEntities.Envelope>(HttpMethods.CallWebService(ConfigurationManager.AppSettings["UAT_URL"], "", HttpMethods.XmlSerialize(CreateLoad(new Envelope()))));
			var gtLoad = GetLoad(response.Body.CreateLoad30Response.LoadId);			
			Assert.AreEqual("200", response.Body.CreateLoad30Response.Response, $"Verify status of the EDI create load response: {response.Body.CreateLoad30Response.Response}");
			Assert.NotNull(response.Body.CreateLoad30Response.LoadId, "Verify the created EDI loadId:" + response.Body.CreateLoad30Response.LoadId);
			Assert.AreEqual("OK", gtLoad.statusCode, "Verify created load through EDI is available in PLS3.0");
			Assert.AreEqual(response.Body.CreateLoad30Response.LoadId, gtLoad.body.loadQBDetails[0].loadId.ToString(),$"Verify EDI Load ID:{response.Body.CreateLoad30Response.LoadId} with PLS3.0 Load ID:{ gtLoad.body.loadQBDetails[0].loadId}");
			ClearLoadExceptions(response.Body.CreateLoad30Response.LoadId);
			var stLoad = loadRest.GetEDIStgedLoads().body.ediStagingLoadsDTO.Find(ld=>ld.loadId==Convert.ToInt32(gtLoad.body.loadQBDetails[0].loadId));
			Assert.AreEqual(gtLoad.body.loadQBDetails[0].loadId, stLoad.loadId, "Verify created EDI load is in staging status after clearing load exceptions.");
		}

		[Test]
		[Description("")]
		public void VerifyEDIComplianceRules()
		{
			UpdateCustomer();
			response1= HttpMethods.XmlDeserialize<SoapService.ResponseEntities.Envelope>(HttpMethods.CallWebService(ConfigurationManager.AppSettings["UAT_URL"], "", HttpMethods.XmlSerialize(CreateLoad(new Envelope()))));
			ClearLoadExceptions(response1.Body.CreateLoad30Response.LoadId);
			var gtLoad = GetLoad(response1.Body.CreateLoad30Response.LoadId);
			Assert.AreEqual("Shipment Planning",gtLoad.body.loadQBDetails[0].loadStatus, "Verify created EDI load is in 'Shipment Planning' status after clearing compliance rules.");


		}


		public CustResponse CreateNewCustomer()
		{	
			var cust = CustomerSvc.CreateCustomer(new CreateCustReq()
			{				
				contacts = _contacts,
				customerNotes = _cutomerNotes,
				customerTags = new List<object>() { },
				billToAddresses = _billtoaddress,			
				accountManager = new EDI_soapAPI.Entities.AccountManager() { },
				customerLocations = _customerLocations,				
				ediRules = new List<EdiRule>(),
				companyName = compName
			}) ;

			return cust;
		}

		public void UpdateCustomer()
		{
			_billtoaddress[0].id = _cust.body.billToAddresses[0].id;
			_customerLocations[0].id = _cust.body.customerLocations[0].id;
			_contacts[0].id = _cust.body.contacts[0].id;
			var cust = CustomerSvc.UpdateCustomer(_cust.body.id, new UpdCustomer()
			{
				id = _cust.body.id,
				contacts = _contacts,
				customerNotes = _cutomerNotes,
				customerTags = new List<object>() { },
				billToAddresses = _billtoaddress,
				//accountManager = new EDI_soapAPI.Entities.AccountManager() { },
				customerLocations = _customerLocations,
				companyName = compName,
				//ediRules = new List<EdiRule>()
				ediRules = new List<EdiRule>()
				{

					new EdiRule()
					{
						@override =false,
						enabled=true,
						active=true,
						location= new Location()
						{
							id ="2124049",
							name =  "WareHouse"
						},
						equipment= new EDI_soapAPI.Entities.Equipment()
						{
							id = "146",
							name = "Flatbed Stretch"
						},
						maxPerDay="2",
						commit="1",

						originCityStateZip ="SCHENECTADY, NY, 12345",
						originCity="SCHENECTADY",
						originState="NY",
						originZipCode="12345",
						destCityStateZip="FORT STORY, VA, 23459",
						destinationCity="FORT STORY",
						destinationState="VA",
						destinationZipCode="23459",
						destinationCityStateZip="FORT STORY, VA, 23459",
						originCountry="United States of America",
						destinationCountry = "United States of America",
						ediRuleCommitTypes=new List<EdiRuleCommitType>()
						{
							new EdiRuleCommitType()
							{
								commitType=new CommitType()
								{
									id="1",
									name = "Daily"
								}
							}
						}

					}
				},
				outboundMessages = true,
				shipsFrequently = false,
				ediCustomer = false,
				firstAddress = new FirstAddress()
				{
					id = 1,
					companyName = compName,
					address1 = "134 main st",
					zipCode = "07047",
					countryName = "United States of America",
					stateCode = "NJ",
					city = "WOODCLIFF",
					contactFirstName = fn,
					contactLastName = ln,
					contactPhone = cphno,
					contactEmail = email,
					isIndividualEmail = false,
					invoiceStyle = "Transactional",
					invoiceFormat = "PDF",
					invoiceAfter = "Delivery",
					invoiceCurrency = "USD",
					invoiceBatchBilling = false,
					frequencyType = null,
					dateOfInvoice = null,
					deliveryMethod = new DeliveryMethod()
					{
						id = "1",
						name = "Do Not Send Invoice"
					},
					dnb = null,
					yearEstablished = null,
					creditAmount = 9000000,
					availableCredit = 9000000,
					unbilledCredit = 0,
					creditOverride = false,
					previousCreditOverride = false,
					creditOverrideDate = 1580954400077,
					active = true,
					paymentTerms = new PaymentTerms()
					{
						id = "1",
						name = "Pre-Paid"
					},
					countryCode = "USA",
					portal = null,
					auditMarginBelowPct = 0,
					auditMarginAbovePct = 70,
					auditMarginAboveAmt = 1500,
					verifyCostBeforeInvoice = false,
					invoiceRequiredFields = new List<object>(),
					invoiceDocuments = new List<object>(),
					bolSignature=null,
					podSignature=null,
					legacyAxAccountNumber= "TB1234-12341",
					axAccountNumber=null,
					legacyBillToId=null,
					increasedCreditAmount=0,
					cityStateZipSearch="WOODCLIFF,NJ,07047",
					isPrevious=false,
					invoiceSettings=null,
					availableCreditOld= 9000000
				},
				customerTagsData=new List<object>()
			}) ;
		}

		public Envelope CreateLoad(Envelope env)
		{
			env = new Envelope()
			{
				Header = new Header()
				{
					AUTHENTICATION = new AUTHENTICATION()
					{
						USERNAME = ConfigurationManager.AppSettings["EDI_UserName"],
						PASSWORD = ConfigurationManager.AppSettings["EDI_Password"],
						//ORG = "229414"
						ORG = _cust.body.id.ToString()
					}
				},
				Body = new SoapService.Entities.Body()
				{
					LoadDTO = new LoadDTO()
					{
						Customer = new Customer()
						{
							//Id = "229414"
							Id = _cust.body.id.ToString()
						},
						CustomerLocation = new SoapService.Entities.CustomerLocation()
						{
							CustomerBillAddress = new SoapService.Entities.CustomerBillAddress()
							{
								//Id = "86043"
								Id = _cust.body.billToAddresses[0].id.ToString()
							}
						},
						LoadCommodities = new LoadCommodities() { },
						LoadOriginDestination = new LoadOriginDestination()
						{
							DestinationPnetDate = "2019-09-23T00:00:00",
							DestinationPnetTime = "12:00:00-05:00",
							DestinationPnltDate = "2019-09-23T00:00:00",
							DestinationPnltTime = "12:00:00-05:00",
							OriginPnetDate = "2019-09-23T00:00:00",
							OriginPnetTime = "12:00:00-05:00",
							OriginPnltDate = "2019-09-23T00:00:00",
							OriginPnltTime = "12:00:00-05:00"

						},
						LoadReferenceFields = new List<LoadReferenceFields>() { },
						LoadStatus = new LoadStatus(),
						Notes=new List<Notes>()
						{
							new Notes()
							{
								NoteTypes = new SoapService.Entities.NoteTypes()
								{
									Id = "1"
								},
								NotesDesc = "Driver must accept load tracking or may face $250 per day not on load tracking rate reduction."
							},
							new Notes()
							{
								NoteTypes = new SoapService.Entities.NoteTypes()
								{
									Id = "1"
								},
								NotesDesc = "Pickup:  Trailer must be food-grade, no odor/debris. TL seal can only be broken by receiver (driver can't break). Detention is only paid if in/out/appt times are noted and signed for on BOL. Weight listed is before pallets/packaging. Drop Trailers A"
							},
							new Notes()
							{
								NoteTypes = new SoapService.Entities.NoteTypes()
								{
									Id = "1"
								},
								NotesDesc = "Drop:  Trailer must be food-grade, no odor/debris. TL seal can only be broken by receiver (driver can't break).Temp. recorder must stay with, and arrive with cargo. Detention is only paid if in/out/appt times are noted and signed for on BOL. Weigh"
							}
						},
						PpdCol = "PPD",
						ShipmentNumber = "AUTO_EDI_"+ Random.RandomNumber(5).ToString()
					}
				}
			};


			return env;
		}

		public LoadSrRes GetLoad(string loadID)
		{
			var load = loadRest.GetLoad(new List<CustSearchReq>()
			{
				new CustSearchReq()
				{
					id= 4,
					modifier= "EQUAL",
					value = loadID,
					condition="AND",
					country= "USA",
					index=0,
					name=null,
					shipperId = _cust.body.id.ToString()
				}

			});		
			return load;
		}

		public void ClearLoadExceptions(string loadId)
		{
			var loads = loadRest.GetLoadException();
			var load = loads.body.ediIssuesDTO.Find(l=>l.loadId == Convert.ToInt32(loadId));
			var initialCount = load.ediExceptionQueueList.Count;
			var currentCount= load.ediExceptionQueueList.Count;
			string updvalue;
			int n = 0;
			do
			{
				loads = loadRest.GetLoadException();
				load = loads.body.ediIssuesDTO.Find(l => l.loadId == Convert.ToInt32(loadId));
				if (load!=null)
				{
					currentCount = load.ediExceptionQueueList.Count;
					if (initialCount != currentCount)
					{
						n = 0;
					}
					Assert.log($"EDI Load Exception found: {load.ediExceptionQueueList[n].ediRejectReasonCode.description}");
					switch (load.ediExceptionQueueList[n].ediRejectReasonCode.id)
					{
						case 2:
							updvalue = "SCHENECTADY, NY, 12345, United States of America";
							break;
						case 3:
							updvalue = "FORT STORY, VA, 23459, United States of America";
							break;
						case 4:
							updvalue = "146";
							break;
						case 8:
							updvalue = "STOCKTON, CA, 95207, United States of America";
							break;
						case 9:
							updvalue = "STKN, CA, 95215, United States of America";
							break;
						case 6:
							updvalue = "Boxes";
							break;
						case 7:
							updvalue = "137";
							break;
						default:
							updvalue = "";
							break;
					}
					var exp = loadRest.ClearExceptions(new EDI_soapAPI.Entities.ExceptionEntities.CleExpReq()
					{
						loadId = Convert.ToInt32(loadId),
						issues = new List<EDI_soapAPI.Entities.ExceptionEntities.Issue>()
					{
						new EDI_soapAPI.Entities.ExceptionEntities.Issue ()
						{
							ediExceptionId =load.ediExceptionQueueList[n].id,
							issueType =load.ediExceptionQueueList[n].ediRejectReasonCode.id,
							description=load.ediExceptionQueueList[n].ediRejectReasonCode.description,
							updatedValue = updvalue,

							country = new EDI_soapAPI.Entities.ExceptionEntities.Country()
							{
								id="USA",
								name="United States of America"
							}
						}
					}


					});
					Assert.AreEqual("200", Convert.ToString(exp.statusCodeValue), $"Cleared exception: {load.ediExceptionQueueList[n].ediRejectReasonCode.description}");
					n++;

				}


			} while(load != null) ;

			//for (int n=0; n< expCount; n++ )
			//{
			//    loads = loadRest.GetLoadException();
			//    load = loads.body.ediIssuesDTO.Find(l => l.loadId == Convert.ToInt32(loadId));
			//	expCount = load.ediExceptionQueueList.Count;
			//	Assert.log($"EDI Load Exception found: {load.ediExceptionQueueList[n].ediRejectReasonCode.description}");
			//	switch (load.ediExceptionQueueList[n].ediRejectReasonCode.id)
			//	{
			//		case 4:
			//			updvalue = "146";
			//			break;
			//		case 8:
			//			updvalue = "STOCKTON, CA, 95207, United States of America";
			//			break;
			//		case 9:
			//			updvalue = "STKN, CA, 95215, United States of America";
			//			break;
			//		case 6:
			//			updvalue = "Boxes";
			//			break;
			//		case 7:
			//			updvalue = "137";
			//			break;
			//		default:
			//			updvalue = "";
			//			break;
			//	}

				//var exp = loadRest.ClearExceptions(new EDI_soapAPI.Entities.ExceptionEntities.CleExpReq()
				//{
				//	loadId = Convert.ToInt32(loadId),
				//	issues = new List<EDI_soapAPI.Entities.ExceptionEntities.Issue>()
				//	{
				//		new EDI_soapAPI.Entities.ExceptionEntities.Issue ()
				//		{
				//			ediExceptionId =load.ediExceptionQueueList[n].id,
				//			issueType =load.ediExceptionQueueList[n].ediRejectReasonCode.id,
				//			description=load.ediExceptionQueueList[n].ediRejectReasonCode.description,
				//			updatedValue = updvalue,
							
				//			country = new EDI_soapAPI.Entities.ExceptionEntities.Country()
				//			{
				//				id="USA",
				//				name="United States of America"
				//			}
				//		}
				//	}


				//});
				//Assert.AreEqual("200", Convert.ToString(exp.statusCodeValue),$"Cleared exception: {load.ediExceptionQueueList[n].ediRejectReasonCode.description}");
			//};
		}

		


	

	


    }
}
