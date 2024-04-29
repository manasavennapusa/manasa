<%@ Page Language="C#" AutoEventWireup="true" CodeFile="confidentialityAggreement.aspx.cs" Inherits="Forms_confidentialityAggreement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <style>
        table.a
        {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
    
        .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
        }
        .letterHead
        {
            padding-top: 180px;
            padding-bottom: 100px;
        } 
         .letterHeadCustom
        {
            padding-top: 280px;
            padding-bottom: 100px;
        } 
    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }
        function letterHead() {
            document.getElementById("letterHead").setAttribute("class", "letterHead");
            document.getElementById("letterHeadOne").setAttribute("class", "letterHead");
            document.getElementById("letterHeadTwo").setAttribute("class", "letterHead");
            document.getElementById("letterHeadThree").setAttribute("class", "letterHeadCustom");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <asp:ScriptManager ID="rr" runat="server"></asp:ScriptManager>
                <asp:Panel ID="pnl1" runat="server" Style="margin-top: 20px">

                    <div class="row-fluid" style="padding-left: 20px; padding-right: 20px;">
                        <div class="span11">
                            <div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group" style="padding-right: 10px; margin: 20px 20px 20px 20px;">
                                            <div>
                                                
                                                <div id="letterHead">
                                                <a style="font-size: 17px;">
                                                    <center><b>Employee Non-Competition, Non-Disclosure and Proprietary Information Agreement</b></center>
                                                </a>

                                                <p>
                                                    This Employee Non-Competition, Non-Disclosure and Proprietary Information Agreement dated as of 
                                              <input title="please enter date in the format DD/MM/YYYY" placeholder="Date of Joining" type="text" style="border-top: none; border-left: none; border-right: none; width: 100px;" />.
                                                  (“Agreement”) is entered into by Escalon Business Services Pvt. Ltd., a company incorporated under the laws of India
having its Corporate Office at Plot No A-40 2nd floor Second Floor SP Infocity Industrial Area Phase 8B Mohali-1600593 (together with its subsidiaries, affiliates,
successors, and assigns, the (“Company”), and the employee whose name and address are set forth at the end of this
Agreement 
                                                  <input title="please enter Employee Full Name" placeholder="Employee Full Name" type="text" style="border-top: none; border-left: none; border-right: none; width: 150px;" />.
     (“Employee”).
                                                </p>
                                                <a style="font-size: 17px;">
                                                    <center><b>INTRODUCTION</b></center>
                                                </a>
                                                <br />

                                                <p>
                                                    Company either employs Employee as an employee or is extending an offer of such employment to Employee concurrently
herewith.
                                                </p>
                                                <p>
                                                    Employee’s relationship with Company is one of confidence and trust. In that relationship Employee may have access to
confidential information of Company (or information of others that is in Company’s possession subject to obligations of
confidentiality and/or nondisclosure), and may develop inventions, copyrightable works or other intellectual property
assets for Company or for such third parties. The parties wish to agree on the confidentiality of such information, the
ownership of such intellectual property assets, and certain other matters.
                                                </p>
                                                <p>
                                                    Therefore, as additional consideration for, and as a condition of, an offer of employment or continued employment as an
employee by Company, and of Employee’s receipt of salary and/or other compensation from Company and other valuable
consideration, and intending to be fully and legally bound, Employee hereby agrees with Company as follows:
                                                </p>
                                                <p>
                                                    <b>1. Confidential Information.</b>
                                                </p>



                                                <p>
                                                    (a) During and after Employee’s employment with Company, Employee will hold in confidence and not use, disclose or
allow disclosure of Confidential Information (as defined below) except in the proper performance of Employee’s duties to
Company. Upon termination of Employee’s employment, Employee will immediately deliver to Company all Confidential
Materials and destroy all electronic embodiments of Confidential Information.
                                                </p>
                                                <p>
                                                    (b)<b> “Confidential Information”</b> means Trade Secrets and other information of Company identified as confidential and
all Work Product, whether disclosed in tangible form (including without limitation written documents, photographs,
drawings, models, prototypes, samples, and magnetic and/or electronic media), or orally or visually or in other nontangible
form (including without limitation presentations, displays or inspections of tangible media or facilities).
Confidential Information shall also include information received by Company from third parties under an obligation of
confidentiality. Confidential Information does not include information which: (i) was known to Employee prior to
disclosure by Company; (ii) is or becomes public knowledge without breach of this Agreement; or (iii) is received by
Employee from a third party without any violation of any obligation of confidentiality and without confidentiality
restrictions.
                                                </p>
                                                <p>
                                                    (c) <b>“Confidential Materials”</b> means tangible objects, materials or media in which Confidential Information is
embodied, including all copies, excerpts, modifications, translations, enhancements and adaptations of the foregoing.
                                                </p>
                                                <p>
                                                    (d)<b> “Intellectual Property”</b> means all rights of every nature relating to intellectual property, including without
limitation (i) all patents and patent applications now or hereafter filed (including continuations, continuations-in-part,
divisionals, reissues, reexaminations and foreign counterparts thereof), and all rights with respect thereto, (ii) all
Trade Secrets, (iii) all trademarks and trademark applications now or hereafter filed, and (iv) all copyrights and
renewals thereof and other rights relating to literary or artistic works and data compilations (including without
limitation author’s and moral rights and rights of publicity and privacy).
                                                </p>
</div>
                                                <div id="letterHeadOne">
                                                <p>
                                                    (e)<b> “Trade Secrets”</b> means all trade secrets under the laws of any jurisdiction, including but not limited to ideas,
inventions, discoveries, developments, designs, improvements, formulae, compounds, organisms, laboratory materials,
prototypes, cell lines, syntheses, know-how, methods, processes, techniques, product specification and performance
data, computer programs, and other data, in each case whether or not patentable, copyrightable or within any
particular definition of trade secret; unpublished proprietary information relating to Company’s Intellectual Property;
and business, marketing, sales, research, development, manufacturing, production and other plans and strategies;
forecasts, financial statements, budgets and projections, licenses, prices and costs; customer and supplier lists and
terms of customer and supplier contracts; personnel information; compilations of such information; and the existence
and terms of this Agreement. Employee’s Work Product is a Trade Secret of Company.
                                                </p>


                                                <p>
                                                    (f) “Work Product” means all tangible and intangible results of Employee’s Services hereunder.
                                                </p>
                                                <p>
                                                    <b>2. Ownership of Work Product and Intellectual Property.</b>
                                                </p>
                                                <p>
                                                    (a) Employee is performing services and creating Work Product hereunder at the instance of Company. It is
therefore the parties’ intention that Company is to own exclusively all rights and economic interests in the Work
Product and all Intellectual Property embodied therein or related thereto, including without limitation any invention or
discovery made or reduced to practice in the process of performing the Services. This Agreement is to be construed to
the maximum extent possible to produce the foregoing result, including but not limited to the construction of any
ambiguities so as to achieve said result.
                                                </p>
                                                <p>
                                                    (b) Accordingly, Employee agrees as follows:
                                                </p>
                                                <p>
                                                    (i) All tangible Work Product which is a copyrightable work of authorship will be deemed a work made for
hire owned by Company under applicable copyright laws; if an invention, Work Product is deemed to be
owned by Company upon creation.
                                                </p>
                                                <p>
                                                    (ii) Employee will maintain adequate and current written records of all Work Product, which shall be
available to and remain the property of Company at all times.
                                                </p>
                                                <p>
                                                    (iii) Employee shall promptly and fully disclose in writing to Company all Trade Secrets, including without
limitation inventions and works of authorship, which are related to the business activities of Company
authored, conceived, created or reduced to practice by Employee (whether alone or jointly with others,
whether during or outside the hours Employee is providing services, and whether or not by the use of
Company’s equipment or other resources) during the term of this Agreement or within six (6) months
thereafter, whether or not patentable or copyrightable.
                                                </p>
                                                <p>
                                                    (iv) Employee hereby assigns irrevocably and unconditionally, to the fullest extent permitted by law under
any interpretation of the relationship between the parties, all right, title and interest (including without
limitation all Intellectual Property rights) embodied in or associated with the Work Product which are
related to the business activities of Company and are authored, conceived, created or reduced to practice
by Employee during the term of this Agreement or which result within six (6) months thereafter from
Confidential Information disclosed by Company
                                                </p>
                                                <p>
                                                    (v) Promptly upon request by Company and at Company’s expense, Employee shall execute and deliver to
Company all applications, assignments, agreements and other instruments and take such reasonable
actions as Company may deem helpful to fully vest the foregoing rights in Company or to evidence such
vesting. If Company is unable, after reasonable effort, to secure Employee's signature on any patent
application, copyright registration or other similar document, Employee hereby irrevocably designates
and appoints Company and its duly authorized representatives as Employee's agent and attorney-in-fact
to execute and file any such application or registration and to do all other lawfully permitted acts to
further the prosecution and issuance of letters patent, copyright registration and other forms of
intellectual property protection with the same legal force and effect as if executed by Employee
                                                </p>
                                                <p>
                                                    (vi) Employee hereby waives in favor of Company and its assigns and licensees any and all artist’s or moral
rights he/she may have pursuant to any applicable laws or statutes in respect of any Works.
                                                </p>



                                               <p> <b>3. Publication.</b> During Employee’s employment, Employee will not publish anything relating to Company's area
of business (including without limitation Inventions, Works and Work Product) without its prior written consent,
which shall not be unreasonably withheld. </b></p>


                                                      </div>
                                                <div id="letterHeadTwo">
                                                    <p>
                                                        <b>4. Covenants Regarding Employees and Customers.</b> For a period of one (1) year after the termination of
Employee’s employment with Company for any reason, Employee will not:
                                                    </p>
                                                    <p>
                                                        (i) recruit, solicit or induce the employment of, offer employment to, or employ any person (or assist
any company or business by which Employee is employed) who was an employee or independent
contractor of Company on or within six (6) months before the termination of Employee’s
employment;
                                                    </p>
                                                  
                                                    <p>
                                                        (ii) solicit any person or entity that was a customer of Company on or within six (6) months before the
date of termination of Employee’s employment; or
(iii) compete with Company directly or indirectly in the development, marketing, sale or distribution of
any product or service for the purpose of, or any business engaged in any business engaged in by
Company at the time of the Employee’s termination, or contemplated as part of Company’s business
or operating plan at the time of Employee’s termination.
                                                    </p>
                                                    <p>
                                                        Employee will not engage in the actions prohibited in clauses (i) through (iii) directly or indirectly, or by being
associated with any person or entity as owner, partner, employee, agent, consultant, director, officer, stockholder
(other than as the owner of less than 2% of the outstanding share capital of a publicly-traded entity) or in any other
capacity or manner whatever.
                                                    </p>
                                                    <p>
                                                        <b>5. Nature of Relationship</b>
                                                    </p>
                                                    <p>
                                                        Employee understands and acknowledges that this Agreement is not an implied or written employment contract for a
specified period of time and that employment with Company is on an “at-will” basis, subject to any applicable notice
period, either agreed to by the parties or provided pursuant to applicable law. Accordingly, Employee understands that
either Employee or Company may terminate Employee’s employment at any time for any or no reason with or without
cause subject to said prior notice period.
                                                    </p>
                                                    <p>
                                                        <b>6. Conflicting Obligations.</b>
                                                    </p>
                                                    <p>
                                                        (a) Employee has not entered into any agreement and is not subject to any obligation which in any way prevents
Employee from being bound by each and every provision of this Agreement or in any way imposes restrictions upon
the use of Employee’s knowledge, skill or expertise to further the business activities of Company. Employee shall
devote his/her full time and best efforts to the business of Company and shall neither pursue any business opportunity
outside Company nor take any position with any organization other than Company without Company’s prior written
approval.
                                                    </p>
                                                    <p>
                                                        (b) Employee does not possess Confidential Information of others except for Confidential Information retained in
unaided memory without the assistance of any device or tangible record, and will not use, disclose to or use on behalf
of Company, or induce Company to use any such Confidential Information of others in connection with Employee’s
employment by Company.
                                                    </p>
                                                    <p>
                                                        <b>7. Miscellaneous.</b>
                                                    </p>
                                                    <p>
                                                        (a) The term <b>“Company”</b> shall mean IntraSoft Technologies Ltd. and any person, corporation or other business
entity that directly, or indirectly through one or more intermediaries, controls, is controlled by, or is under common
control with, Company.
                                                    </p>
                                                    <p>
                                                        (b) If any provision of this Agreement is invalid, illegal or unenforceable in any respect, the validity, legality and
enforceability in every other respect of such provision and of the remaining provisions shall not in any way be affected
or impaired thereby. If a court determines that any provision herein is invalid, illegal or unenforceable, for any reason,
such provision shall be deemed amended to the extent necessary to comply with such determination, and such
provision, as so amended, shall be valid and binding as though the invalid, illegal or unenforceable portion had not
been included herein.
                                                    </p>
                                                    </div>
                                                <div id="letterHeadThree">
                                                    <p>
                                                        (c) Employee recognizes that irreparable injury, which could not be adequately compensated by money damages,
may result to Company if Employee breaches the promises Employee has made in this Agreement, and that
Employee’s employment is based on those promises. Employee therefore agrees that in the event of Employee’s breach
or threatened breach of any of those promises, Company shall be entitled to injunctive or other equitable relief
restraining such breach or threatened breach, without having to prove (beyond entering this Agreement into evidence)
either the fact of irreparable injury or the inadequacy of money damages. Such relief shall be without prejudice to any
other remedy to which Company may be entitled.
                                                    </p>
                                                    <p>
                                                        (d) This Agreement shall be binding upon and shall inure to the benefit of the parties, their successors, assigns and
legal representatives, may be amended only in writing, and shall be governed by and construed in accordance with the
laws of the Republic of India. Any action or proceeding arising out of or related to this Agreement shall be brought
only in courts which have jurisdiction and venue over the proceeding and the then location of Company’s principal
offices. This Agreement sets forth the entire agreement between the parties as to the subject matter hereof and
supercedes any and all other agreements, negotiations, discussions, proposals or understandings, whether oral or
written, concerning the subject matter set forth herein.
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>


                                                    <p>
                                                      <center> [Remainder of Page Intetionally Left Blank]</center>
                                                    </p>


                                               <p> EMPLOYEE UNDERSTANDS AND ACKNOWLEDGES THAT THIS AGREEMENT AFFECTS SIGNIFICANT LEGAL
RIGHTS. EMPLOYEE HAS READ AND FULLY UNDERSTANDS EACH PROVISION OF THIS AGREEMENT. EMPLOYEE
HAS HAD THE OPPORTUNITY TO CONSULT, TO THE EXTENT DESIRED, WITH AN ATTORNEY OF EMPLOYEE’S
OWN CHOOSING.</p>
                                                <p>
IN WITNESS WHEREOF, Employee and Company hereby execute this Agreement as of the date set forth above.</p>
                                                <table>
                                                    <tr>
                                                       <td style="width:70%">
                                                            <p><b>Company:</b></p>
                                                            <p>By:_________________________</p>
                                                            <br/>
                                                            <p>Authorised Signature</p>
                                                            <p>Name:________________________</p>
                                                            <p>Title:________________________</p>
                                                            <p>Witness:________________________</p>
                                                        </td>
                                                        <td style="width:70%">
                                                            <p><b>Employee:</b></p>
                                                            <p>Name:________________________</p>
                                                            <p>Son/Daughter/Wife of:_________________________</p>
                                                            <br/>
                                                           
                                                            
                                                            <p>Address:________________________</p>
                                                            <p style="padding-left:50px">________________________</p>
                                                            <p style="padding-left:50px">________________________</p>
                                                            <p>Witness:________________________</p>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </div>
                                            </div>
                                            <br />
                                            <br />
                                          
                                            

                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide(); window.print();" class="btn btn-info pull-right" /><br />
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>


            </div>
        </div>

    </form>
</body>
</html>
