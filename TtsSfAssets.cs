// SF API version v48.0
// Custom fields included: True
// Relationship objects included: True

using NetCoreForce.Client.Attributes;
using NetCoreForce.Client.Models;
using NetCoreForce.Models;
using Newtonsoft.Json;
using System;

namespace Tts.Microservices.Products.Generated
{
    ///<summary>
    /// Tool
    ///<para>SObject Name: Asset</para>
    ///<para>Custom Object: False</para>
    ///</summary>
    public class TtsSfAsset : SObject
    {
        [JsonIgnore]
        public static string SObjectTypeName
        {
            get { return "Asset"; }
        }

        ///<summary>
        /// Manufacture Date
        /// <para>Name: ManufactureDate</para>
        /// <para>SF Type: date</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "manufactureDate")]
        public DateTime? ManufactureDate { get; set; }

        ///<summary>
        /// Tool ID
        /// <para>Name: Id</para>
        /// <para>SF Type: id</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "id")]
        [Updateable(false), Createable(false)]
        public string Id { get; set; }

        ///<summary>
        /// Contact ID (do not use for reporting!)
        /// <para>Name: ContactId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "contactId")]
        public string ContactId { get; set; }

        ///<summary>
        /// ReferenceTo: Contact
        /// <para>RelationshipName: Contact</para>
        ///</summary>
        [JsonProperty(PropertyName = "contact")]
        [Updateable(false), Createable(false)]
        public TtsSfContact Contact { get; set; }

        ///<summary>
        /// Account ID
        /// <para>Name: AccountId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

        ///<summary>
        /// ReferenceTo: Account
        /// <para>RelationshipName: Account</para>
        ///</summary>
        [JsonProperty(PropertyName = "account")]
        [Updateable(false), Createable(false)]
        public SfAccount Account { get; set; }

        ///<summary>
        /// Parent Tool
        /// <para>Name: ParentId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "parentId")]
        public string ParentId { get; set; }

        ///<summary>
        /// ReferenceTo: Asset
        /// <para>RelationshipName: Parent</para>
        ///</summary>
        [JsonProperty(PropertyName = "parent")]
        [Updateable(false), Createable(false)]
        public TtsSfAsset Parent { get; set; }

        ///<summary>
        /// Root Tool
        /// <para>Name: RootAssetId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "rootAssetId")]
        [Updateable(false), Createable(false)]
        public string RootAssetId { get; set; }

        ///<summary>
        /// ReferenceTo: Asset
        /// <para>RelationshipName: RootAsset</para>
        ///</summary>
        [JsonProperty(PropertyName = "rootAsset")]
        [Updateable(false), Createable(false)]
        public TtsSfAsset RootAsset { get; set; }

        ///<summary>
        /// Product ID
        /// <para>Name: Product2Id</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "product2Id")]
        public string Product2Id { get; set; }

        ///<summary>
        /// ReferenceTo: Product2
        /// <para>RelationshipName: Product2</para>
        ///</summary>
        [JsonProperty(PropertyName = "product2")]
        [Updateable(false), Createable(false)]
        public SfProduct2 Product2 { get; set; }

        ///<summary>
        /// Material Number
        /// <para>Name: ProductCode</para>
        /// <para>SF Type: string</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "productCode")]
        [Updateable(false), Createable(false)]
        public string ProductCode { get; set; }

        ///<summary>
        /// Competitor
        /// <para>Name: IsCompetitorProduct</para>
        /// <para>SF Type: boolean</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isCompetitorProduct")]
        public bool? IsCompetitorProduct { get; set; }

        ///<summary>
        /// Created Date
        /// <para>Name: CreatedDate</para>
        /// <para>SF Type: datetime</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "createdDate")]
        [Updateable(false), Createable(false)]
        public DateTimeOffset? CreatedDate { get; set; }

        ///<summary>
        /// Created By ID
        /// <para>Name: CreatedById</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "createdById")]
        [Updateable(false), Createable(false)]
        public string CreatedById { get; set; }

        ///<summary>
        /// Last Modified Date
        /// <para>Name: LastModifiedDate</para>
        /// <para>SF Type: datetime</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "lastModifiedDate")]
        [Updateable(false), Createable(false)]
        public DateTimeOffset? LastModifiedDate { get; set; }

        ///<summary>
        /// Last Modified By ID
        /// <para>Name: LastModifiedById</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "lastModifiedById")]
        [Updateable(false), Createable(false)]
        public string LastModifiedById { get; set; }

        ///<summary>
        /// System Modstamp
        /// <para>Name: SystemModstamp</para>
        /// <para>SF Type: datetime</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "systemModstamp")]
        [Updateable(false), Createable(false)]
        public DateTimeOffset? SystemModstamp { get; set; }

        ///<summary>
        /// Deleted
        /// <para>Name: IsDeleted</para>
        /// <para>SF Type: boolean</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isDeleted")]
        [Updateable(false), Createable(false)]
        public bool? IsDeleted { get; set; }

        ///<summary>
        /// Tool Currency
        /// <para>Name: CurrencyIsoCode</para>
        /// <para>SF Type: picklist</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "currencyIsoCode")]
        public string CurrencyIsoCode { get; set; }

        ///<summary>
        /// TNR / SNR
        /// <para>Name: Name</para>
        /// <para>SF Type: string</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        ///<summary>
        /// Serial Number
        /// <para>Name: SerialNumber</para>
        /// <para>SF Type: string</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        ///<summary>
        /// Install Date
        /// <para>Name: InstallDate</para>
        /// <para>SF Type: date</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "installDate")]
        public DateTime? InstallDate { get; set; }

        ///<summary>
        /// Purchase Date
        /// <para>Name: PurchaseDate</para>
        /// <para>SF Type: date</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "purchaseDate")]
        public DateTime? PurchaseDate { get; set; }

        ///<summary>
        /// Usage End Date
        /// <para>Name: UsageEndDate</para>
        /// <para>SF Type: date</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "usageEndDate")]
        public DateTime? UsageEndDate { get; set; }

        ///<summary>
        /// Status
        /// <para>Name: Status</para>
        /// <para>SF Type: picklist</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        ///<summary>
        /// Price
        /// <para>Name: Price</para>
        /// <para>SF Type: currency</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "price")]
        public decimal? Price { get; set; }

        ///<summary>
        /// Quantity
        /// <para>Name: Quantity</para>
        /// <para>SF Type: double</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "quantity")]
        public double? Quantity { get; set; }

        ///<summary>
        /// Description
        /// <para>Name: Description</para>
        /// <para>SF Type: textarea</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        ///<summary>
        /// Tool Owner
        /// <para>Name: OwnerId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "ownerId")]
        public string OwnerId { get; set; }

        ///<summary>
        /// Tool Record Type
        /// <para>Name: RecordTypeId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "recordTypeId")]
        public string RecordTypeId { get; set; }

        ///<summary>
        /// ReferenceTo: RecordType
        /// <para>RelationshipName: RecordType</para>
        ///</summary>
        [JsonProperty(PropertyName = "recordType")]
        [Updateable(false), Createable(false)]
        public SfRecordType RecordType { get; set; }

        ///<summary>
        /// Location ID
        /// <para>Name: LocationId</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "locationId")]
        public string LocationId { get; set; }

        ///<summary>
        /// Tool Provided By
        /// <para>Name: AssetProvidedById</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "assetProvidedById")]
        public string AssetProvidedById { get; set; }

        ///<summary>
        /// Tool Serviced By
        /// <para>Name: AssetServicedById</para>
        /// <para>SF Type: reference</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "assetServicedById")]
        public string AssetServicedById { get; set; }

        ///<summary>
        /// Internal Tool
        /// <para>Name: IsInternal</para>
        /// <para>SF Type: boolean</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isInternal")]
        public bool? IsInternal { get; set; }

        ///<summary>
        /// Tool Level
        /// <para>Name: AssetLevel</para>
        /// <para>SF Type: int</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "assetLevel")]
        [Updateable(false), Createable(false)]
        public int? AssetLevel { get; set; }

        ///<summary>
        /// Product SKU
        /// <para>Name: StockKeepingUnit</para>
        /// <para>SF Type: string</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "stockKeepingUnit")]
        [Updateable(false), Createable(false)]
        public string StockKeepingUnit { get; set; }

        ///<summary>
        /// Last Viewed Date
        /// <para>Name: LastViewedDate</para>
        /// <para>SF Type: datetime</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "lastViewedDate")]
        [Updateable(false), Createable(false)]
        public DateTimeOffset? LastViewedDate { get; set; }

        ///<summary>
        /// Last Referenced Date
        /// <para>Name: LastReferencedDate</para>
        /// <para>SF Type: datetime</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "lastReferencedDate")]
        [Updateable(false), Createable(false)]
        public DateTimeOffset? LastReferencedDate { get; set; }

        ///<summary>
        /// Reference Number
        /// <para>Name: WarrantyNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>AutoNumber field</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "warrantyNumber__c")]
        [Updateable(false), Createable(false)]
        public string WarrantyNumber__c { get; set; }

        ///<summary>
        /// Warranty Number (old)
        /// <para>Name: LegacyWarrantyNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "legacyWarrantyNumber__c")]
        public string LegacyWarrantyNumber__c { get; set; }

        ///<summary>
        /// Terms and Conditions Version
        /// <para>Name: TermsAndConditionsVersion__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "termsAndConditionsVersion__c")]
        public string TermsAndConditionsVersion__c { get; set; }

        ///<summary>
        /// Is Financed
        /// <para>Name: IsFinanced__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isFinanced__c")]
        public bool? IsFinanced__c { get; set; }

        ///<summary>
        /// Contract Number
        /// <para>Name: FinancialContractNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "financialContractNumber__c")]
        public string FinancialContractNumber__c { get; set; }

        ///<summary>
        /// Financial Partner
        /// <para>Name: FinancialPartner__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "financialPartner__c")]
        public string FinancialPartner__c { get; set; }

        ///<summary>
        /// Source
        /// <para>Name: Source__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "source__c")]
        public string Source__c { get; set; }

        ///<summary>
        /// Used Tool
        /// <para>Name: HasBeenUsed__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "hasBeenUsed__c")]
        public bool? HasBeenUsed__c { get; set; }

        ///<summary>
        /// Warranty Until
        /// <para>Name: WarrantyUntilDate__c</para>
        /// <para>SF Type: date</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "warrantyUntilDate__c")]
        public DateTime? WarrantyUntilDate__c { get; set; }

        ///<summary>
        /// Dealer (delivered to)
        /// <para>Name: AssetDeliveredToId__c</para>
        /// <para>SF Type: reference</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "assetDeliveredToId__c")]
        public string AssetDeliveredToId__c { get; set; }

        ///<summary>
        /// Is Replacement Device
        /// <para>Name: IsReplacementDevice__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isReplacementDevice__c")]
        public bool? IsReplacementDevice__c { get; set; }

        ///<summary>
        /// Replacement Reason
        /// <para>Name: ReplacementReason__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "replacementReason__c")]
        public string ReplacementReason__c { get; set; }

        ///<summary>
        /// Delivery Note Number
        /// <para>Name: DeliveryNoteNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "deliveryNoteNumber__c")]
        public string DeliveryNoteNumber__c { get; set; }

        ///<summary>
        /// Delivery Date
        /// <para>Name: DeliveryDate__c</para>
        /// <para>SF Type: date</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "deliveryDate__c")]
        public DateTime? DeliveryDate__c { get; set; }

        ///<summary>
        /// Article Number
        /// <para>Name: SalesNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "salesNumber__c")]
        public string SalesNumber__c { get; set; }

        ///<summary>
        /// Registration Date
        /// <para>Name: RegistrationDate__c</para>
        /// <para>SF Type: datetime</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "registrationDate__c")]
        public DateTimeOffset? RegistrationDate__c { get; set; }

        ///<summary>
        /// Material Number
        /// <para>Name: ProductCode__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "productCode__c")]
        public string ProductCode__c { get; set; }

        ///<summary>
        /// Replacement Device
        /// <para>Name: ReplacementAssetId__c</para>
        /// <para>SF Type: reference</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "replacementAssetId__c")]
        public string ReplacementAssetId__c { get; set; }

        ///<summary>
        /// ReferenceTo: Asset
        /// <para>RelationshipName: ReplacementAssetId__r</para>
        ///</summary>
        [JsonProperty(PropertyName = "replacementAssetId__r")]
        [Updateable(false), Createable(false)]
        public TtsSfAsset ReplacementAssetId__r { get; set; }

        ///<summary>
        /// Warranty Claim
        /// <para>Name: Warranty_Claim__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "warranty_Claim__c")]
        public string Warranty_Claim__c { get; set; }

        ///<summary>
        /// Warranty Claim Indicator
        /// <para>Name: Warranty_Claim_Indicator__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "warranty_Claim_Indicator__c")]
        [Updateable(false), Createable(false)]
        public string Warranty_Claim_Indicator__c { get; set; }

        ///<summary>
        /// Machine Type &amp; TNR
        /// <para>Name: ProductName__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "productName__c")]
        [Updateable(false), Createable(false)]
        public string ProductName__c { get; set; }

        ///<summary>
        /// Warranty Expired
        /// <para>Name: WarrantyExpired__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "warrantyExpired__c")]
        public bool? WarrantyExpired__c { get; set; }

        ///<summary>
        /// Warranty expires today
        /// <para>Name: WarrantyExpiresToday__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "warrantyExpiresToday__c")]
        [Updateable(false), Createable(false)]
        public bool? WarrantyExpiresToday__c { get; set; }

        ///<summary>
        /// Original Warranty Number
        /// <para>Name: OriginalWarrantyNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "originalWarrantyNumber__c")]
        public string OriginalWarrantyNumber__c { get; set; }

        ///<summary>
        /// Unique Device Identifier
        /// <para>Name: UniqueDeviceIdentifier__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "uniqueDeviceIdentifier__c")]
        public string UniqueDeviceIdentifier__c { get; set; }

        ///<summary>
        /// SAP Order Number
        /// <para>Name: OrderNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "orderNumber__c")]
        public string OrderNumber__c { get; set; }

        ///<summary>
        /// Guest Account Name
        /// <para>Name: GuestAccountName__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestAccountName__c")]
        public string GuestAccountName__c { get; set; }

        ///<summary>
        /// Guest Contact Name
        /// <para>Name: GuestContactName__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestContactName__c")]
        public string GuestContactName__c { get; set; }

        ///<summary>
        /// Guest Billing Address
        /// <para>Name: GuestBillingAddress__c</para>
        /// <para>SF Type: textarea</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestBillingAddress__c")]
        public string GuestBillingAddress__c { get; set; }

        ///<summary>
        /// Guest Billing Country
        /// <para>Name: GuestBillingCountryCode__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestBillingCountryCode__c")]
        public string GuestBillingCountryCode__c { get; set; }

        ///<summary>
        /// Guest Industry
        /// <para>Name: GuestIndustry__c</para>
        /// <para>SF Type: picklist</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestIndustry__c")]
        public string GuestIndustry__c { get; set; }

        ///<summary>
        /// Guest Customer Number (Old)
        /// <para>Name: GuestLegacyCustomerNumber__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestLegacyCustomerNumber__c")]
        public string GuestLegacyCustomerNumber__c { get; set; }

        ///<summary>
        /// Guest Contact ID (Old)
        /// <para>Name: GuestLegacyContactId__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestLegacyContactId__c")]
        public string GuestLegacyContactId__c { get; set; }

        ///<summary>
        /// Unique Registration Identifier
        /// <para>Name: UniqueRegistrationId__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "uniqueRegistrationId__c")]
        [Updateable(false), Createable(false)]
        public string UniqueRegistrationId__c { get; set; }

        ///<summary>
        /// Dealer (bought at)
        /// <para>Name: AssetBoughtAtId__c</para>
        /// <para>SF Type: reference</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "assetBoughtAtId__c")]
        public string AssetBoughtAtId__c { get; set; }

        ///<summary>
        /// Is Hidden in Open Replacement Devices
        /// <para>Name: IsHiddenInOpenReplacementDevices__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isHiddenInOpenReplacementDevices__c")]
        public bool? IsHiddenInOpenReplacementDevices__c { get; set; }

        ///<summary>
        /// Removed in MyFestool
        /// <para>Name: IsHiddenInMyFestool__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isHiddenInMyFestool__c")]
        public bool? IsHiddenInMyFestool__c { get; set; }

        ///<summary>
        /// FiscalYear
        /// <para>Name: FiscalYear__c</para>
        /// <para>SF Type: double</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "fiscalYear__c")]
        [Updateable(false), Createable(false)]
        public double? FiscalYear__c { get; set; }

        ///<summary>
        /// Account BillingCountry
        /// <para>Name: AccountBillingCountry__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "accountBillingCountry__c")]
        public string AccountBillingCountry__c { get; set; }

        ///<summary>
        /// Delivered To BillingCountry
        /// <para>Name: DeliveredToBillingCountry__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "deliveredToBillingCountry__c")]
        public string DeliveredToBillingCountry__c { get; set; }

        ///<summary>
        /// Bought at BillingCountry
        /// <para>Name: BoughtAtBillingCountry__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "boughtAtBillingCountry__c")]
        public string BoughtAtBillingCountry__c { get; set; }

        ///<summary>
        /// Guest Email
        /// <para>Name: GuestEmail__c</para>
        /// <para>SF Type: email</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestEmail__c")]
        public string GuestEmail__c { get; set; }

        ///<summary>
        /// Guest Phone
        /// <para>Name: GuestPhone__c</para>
        /// <para>SF Type: phone</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestPhone__c")]
        public string GuestPhone__c { get; set; }

        ///<summary>
        /// Guest Mobile Phone
        /// <para>Name: GuestMobilePhone__c</para>
        /// <para>SF Type: phone</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestMobilePhone__c")]
        public string GuestMobilePhone__c { get; set; }

        ///<summary>
        /// Guest Date of Agreement to Save Email
        /// <para>Name: GuestDateOfAgreementToSaveEmail__c</para>
        /// <para>SF Type: datetime</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "guestDateOfAgreementToSaveEmail__c")]
        public DateTimeOffset? GuestDateOfAgreementToSaveEmail__c { get; set; }

        ///<summary>
        /// Dealer (replacement handled by)
        /// <para>Name: ReplacementHandledById__c</para>
        /// <para>SF Type: reference</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "replacementHandledById__c")]
        public string ReplacementHandledById__c { get; set; }

        ///<summary>
        /// Customer Tool Notes
        /// <para>Name: CustomerToolNotes__c</para>
        /// <para>SF Type: textarea</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "customerToolNotes__c")]
        public string CustomerToolNotes__c { get; set; }

        ///<summary>
        /// Product Category Portal
        /// <para>Name: ProductCategoryPortal__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "productCategoryPortal__c")]
        public string ProductCategoryPortal__c { get; set; }

        ///<summary>
        /// Toolpoints
        /// <para>Name: ToolPoints__c</para>
        /// <para>SF Type: double</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "toolPoints__c")]
        [Updateable(false), Createable(false)]
        public double? ToolPoints__c { get; set; }

        ///<summary>
        /// Country (for Reporting)
        /// <para>Name: ReportingCountry__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "reportingCountry__c")]
        [Updateable(false), Createable(false)]
        public string ReportingCountry__c { get; set; }

        ///<summary>
        /// Relevant for current User
        /// <para>Name: IsRelevantForCurrentUser__c</para>
        /// <para>SF Type: boolean</para>
        /// <para>Custom field</para>
        /// <para>Nillable: False</para>
        ///</summary>
        [JsonProperty(PropertyName = "isRelevantForCurrentUser__c")]
        [Updateable(false), Createable(false)]
        public bool? IsRelevantForCurrentUser__c { get; set; }

        ///<summary>
        /// Nickname
        /// <para>Name: Nickname__c</para>
        /// <para>SF Type: string</para>
        /// <para>Custom field</para>
        /// <para>Nillable: True</para>
        ///</summary>
        [JsonProperty(PropertyName = "nickname__c")]
        public string Nickname__c { get; set; }

    }
}
